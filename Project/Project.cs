using BIMStructureMgd.Common;
//Пространства имён nanoCAD BIM Строительство
using BIMStructureMgd.DatabaseObjects;
using BIMStructureMgd.ObjectProperties;
using HostMgd.ApplicationServices;
using HostMgd.EditorInput;

using ObjectLibrary.Table;
using ParametricKit;
using ParametricKit.Tree;
using ParametricKit.Tree.Eval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
//Стандартные пространства имён платформы nanoCAD
using Teigha.DatabaseServices;
using Teigha.Geometry;
using Teigha.Runtime;
using NativePlatform = Teigha;
using Platform = HostMgd;

namespace Project
{
    public class Project
    {

        [CommandMethod("NSC_TABLE")]

        public static void Createtable ()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            PromptPointOptions options =
            new PromptPointOptions("\nУкажите точку вставки стола: ");

            PromptPointResult result =
                doc.Editor.GetPoint(options);

            if (result.Status != PromptStatus.OK)
                return;

            Point3d insertPoint = result.Value;

            TableSpecification specification = new TableSpecification();

            specification.PointX = insertPoint.X;
            specification.PointY = insertPoint.Y;
            specification.PointZ = insertPoint.Z;

            var topTable = new ObjectLibrary.Table.Table(specification);

            var collector = new Collector();
            var tree = collector.Collect(topTable);

            //var collector = new TreeCollector();
            //var tree = StructureTree.CreateDefault();
            //collector.Collect(topTable, tree);

            var converter = new TreeToParametricEntityConverter();
            var top = converter.Convert(tree);

            top.UpdateElements();
            top.ReCalculateParametric(ViewMode.Plan2D);

            using Transaction tr = db.TransactionManager.StartTransaction();
            BIMStructureMgd.Common.Utilities.AddEntityToDatabase(db, tr, top);
            tr.Commit();

        }


        //[CommandMethod("nBIMSDK_CreateBoxObject")]
        //public static void CreateBoxObject()
        //{
        //    Document doc = Application.DocumentManager.MdiActiveDocument;
        //    Database db = doc.Database;

        //    var boxObject = new BoxObject(new BoxObjectSpecification());

        //    var collector = new Collector();
        //    var tree = collector.Collect(boxObject);

        //    //var collector = new TreeCollector();
        //    //var tree = StructureTree.CreateDefault();
        //    //collector.Collect(boxObject, tree);

        //    var converter = new TreeToParametricEntityConverter();
        //    var box = converter.Convert(tree);
        //    var Leg1C = converter.Convert(tree);

        //    box.UpdateElements();
        //    box.ReCalculateParametric(ViewMode.Plan2D);

        //    Leg1C.UpdateElements();
        //    Leg1C.ReCalculateParametric(ViewMode.Plan2D);


        //    using Transaction tr = db.TransactionManager.StartTransaction();
        //    BIMStructureMgd.Common.Utilities.AddEntityToDatabase(db, tr, box);
        //    //BIMStructureMgd.Common.Utilities.AddEntityToDatabase(db, tr, Leg1C);
        //    tr.Commit();
        //}
    }
    
}
