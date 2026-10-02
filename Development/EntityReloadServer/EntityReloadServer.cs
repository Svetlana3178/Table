//Пространства имён nanoCAD BIM Строительство
using BIMStructureMgd.DatabaseObjects;
using BIMStructureMgd.ObjectProperties;
using HostMgd.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
//Стандартные пространства имён платформы nanoCAD
using Teigha.DatabaseServices;
using Teigha.Geometry;
using Teigha.Runtime;
using NativePlatform = Teigha;
using Platform = HostMgd;

namespace EntityReload
{
    public class EntityReloaderServer : IExtensionApplication
    {
        public void Initialize()
        {
        }

        public void Terminate()
        {
            InternalServer.Stop();
        }

        [CommandMethod("nBIMSDK_EntityReloadServer_Start")]
        public static void StartEntityReloadServer()
        {
            Document doc = Platform.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            if (InternalServer.Running)
            {
                doc.Editor.WriteMessage("Сервер уже запущен.");
            }
            else if (InternalServer.Start(doc))
            {
                doc.Editor.WriteMessage("Сервер запущен.");
            }
            else
            {
                doc.Editor.WriteMessage("Не удалось запустить сервер.");
            }
        }

        [CommandMethod("nBIMSDK_EntityReloadServer_Stop")]
        public static void StopEntityReloadServer()
        {
            Document doc = Platform.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            if (!InternalServer.Running)
            {
                doc?.Editor.WriteMessage("Сервер не был запущен.");
            }
            else if (InternalServer.Stop())
            {
                doc?.Editor.WriteMessage("Сервер остановлен.");
            }
            else
            {
                doc?.Editor.WriteMessage("Не удалось остановить сервер.");
            }
        }
    }
}
