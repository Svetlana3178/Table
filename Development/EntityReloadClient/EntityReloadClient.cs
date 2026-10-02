using System.IO.Pipes;
using System.Xml.Serialization;
using ParametricKit;
using ParametricKit.Tree;
using ParametricKit.Tree.Eval;
using ParametricKit.Xpg;

namespace EntityReload
{
    public static class EntityReloadClient
    {
        public static void Reload(IEntitySource entitySource)
        {
            var collector = new Collector();
            var tree = collector.Collect(entitySource);

            //var collector = new TreeCollector();
            //var tree = StructureTree.CreateDefault();
            //collector.Collect(entitySource, tree);

            //collector.Collect(entitySource);

            var converter = new TreeToXpgConverter();
            var xpg = converter.Convert(tree);

            using var pipeClient = new NamedPipeClientStream(".", "EntityReloadServerStream", PipeDirection.Out);
            pipeClient.Connect();
            var serializer = new XmlSerializer(typeof(Parametric));
            using var writer = new StreamWriter(pipeClient);
            serializer.Serialize(writer, xpg);
            writer.Flush();

            Console.WriteLine($"{xpg.Specification.Element.Name} обновлен");
        }
    }
}
