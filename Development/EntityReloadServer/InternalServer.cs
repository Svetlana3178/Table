using HostMgd.ApplicationServices;
using System.IO.Pipes;

namespace EntityReload
{
    internal class InternalServer
    {
        private static InternalServer? m_Instance;

        private CancellationTokenSource? m_cancellationTokenSource;

        private Task? m_CurrentTask;

        private EntityLoader? m_EntityLoader;

        private Document? m_Document;

        private InternalServer(Document document)
        {
            m_Document = document;
            m_EntityLoader = new EntityLoader(document);
            m_Document.BeginDocumentClose += DocumentCloseHandler;
        }

        public static bool Start(Document document)
        {
            if (Running)
            {
                return false;
            }

            if (m_Instance == null)
            {
                m_Instance = new InternalServer(document);
            }

            return m_Instance.StartInternal();
        }

        public static bool Running
        {
            get
            {
                return m_Instance != null;
            }
        }

        public static bool Stop()
        {
            if (!Running)
            {
                return false;
            }

            bool result = false;
            if (m_Instance != null)
            {
                result = m_Instance.StopInternal();
                m_Instance = null;
            }

            return result;
        }

        private bool StartInternal()
        {
            try
            {
                m_cancellationTokenSource = new CancellationTokenSource();

                var token = m_cancellationTokenSource.Token;

                m_CurrentTask =
                    Task.Run(() =>
                    {
                        while (!token.IsCancellationRequested)
                        {
                            try
                            {
                                using var pipeServer = new NamedPipeServerStream("EntityReloadServerStream", PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
                                var connectionTask = pipeServer.WaitForConnectionAsync(token);
                                Task.WaitAny(new[] { connectionTask }, token);
                                if (!token.IsCancellationRequested)
                                {
                                    using var reader = new StreamReader(pipeServer);
                                    m_EntityLoader?.Load(reader);
                                }
                            }
                            catch (Exception ex)
                            {
                                WriteMessage(ex.Message);
                            }
                        }
                    }, m_cancellationTokenSource.Token);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool StopInternal()
        {
            try
            {
                m_cancellationTokenSource?.Cancel();
                Task.WaitAll(new[] { m_CurrentTask! });
            }
            catch
            {
                return false;
            }
            finally
            {
                m_EntityLoader?.Dispose();
                m_EntityLoader = null;
                m_cancellationTokenSource?.Dispose();
                m_cancellationTokenSource = null;
                m_CurrentTask?.Dispose();
                m_CurrentTask = null;
                m_Document = null;
            }   

            return true;
        }

        private void WriteMessage(string s) => m_Document?.Editor.WriteMessage(s);

        private void DocumentCloseHandler(object sender, DocumentBeginCloseEventArgs e)
        {
            if (m_Document != null)
            {
                m_Document.BeginDocumentClose -= DocumentCloseHandler;
            }
            WriteMessage("Сервер остановлен");
            m_Document = null;

            Stop();
        }
    }
}
