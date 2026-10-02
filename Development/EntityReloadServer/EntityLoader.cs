using System.Xml.Serialization;
using Teigha.DatabaseServices;
using BIMStructureMgd.DatabaseObjects;
using ParametricKit.Utilities;
using ParametricKit.Xpg;

namespace EntityReload
{
    internal class EntityLoader : IDisposable
    {
        private ObjectId m_ObjectId;

        private HostMgd.ApplicationServices.Document? m_CurrentDocument;

        public EntityLoader(HostMgd.ApplicationServices.Document document)
        {
            m_ObjectId = ObjectId.Null;
            m_CurrentDocument = document;
        }

        public void Dispose()
        {
            m_CurrentDocument = null;
            m_ObjectId = ObjectId.Null;
        }

        public void Load(StreamReader reader)
        {
            var serializer = new XmlSerializer(typeof(Parametric));
            var data =
                serializer.Deserialize(reader) as Parametric
                ?? throw new InvalidDataException("Неверный формат данных");

            if (m_ObjectId.IsNull)
            {
                CreateObject();
            }

            using Transaction tr = m_ObjectId.Database.TransactionManager.StartTransaction();

            ParametricEntBase? entity = m_ObjectId.GetObject(OpenMode.ForWrite) as ParametricEntBase;
            
            if (entity == null)
            {
                CreateObject();
                entity = m_ObjectId.GetObject(OpenMode.ForWrite) as ParametricEntBase;
            }

            if (entity == null)
            {
                throw new InvalidDataException("Не удалось создать объект");
            }
            
            var gen = new XpgParametricEntityConverter();
            var newEntity = gen.Convert(data);

            entity.CopyFrom(newEntity);

            entity.UpdateElements();

            tr.Commit();
        }

        private void CreateObject()
        {
            if (m_CurrentDocument == null)
            {
                throw new InvalidDataException("Не задан документ");
            }

            var entity = ParametricEntityFactory.Create();
            var db = m_CurrentDocument.Database;

            using Transaction tr = m_CurrentDocument.TransactionManager.StartTransaction();
            m_ObjectId = BIMStructureMgd.Common.Utilities.AddEntityToDatabase(db, tr, entity);
            tr.Commit();
        }
    }
}
