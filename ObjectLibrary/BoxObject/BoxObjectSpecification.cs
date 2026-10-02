using ParametricKit;
using ParametricKit.Attributes;
using ParametricKit.FunctionWizard;

namespace ObjectLibrary.BoxObject
{
    public class ChildObjectSpecification : EntitySpecification
    {
        public ChildObjectSpecification()
        {
            Name = "Материал";
        }

        [ParameterDefinition("BUILD_MATERIAL_ID")]

        public SpecificationParameter MaterialId { get; set; } = FuncWiz.L("ОТ-055");

    }

    public class BoxObjectSpecification : EntitySpecification
    {


        public BoxObjectSpecification()
        {
            Name = "Параметрический объект";
            ChildObject = new();

        }


        [ParameterDefinition("DIM_HEIGHT")]
        public SpecificationParameter Height { get; set; } = 2000;

        [ParameterDefinition("DIM_LENGTH")]
        public SpecificationParameter Lenght { get; set; } = 1000;

        [ParameterDefinition("DIM_WIDTH")]
        public SpecificationParameter Width { get; set; } = 1000;

        public ChildObjectSpecification ChildObject { get; set; }

        //[ParameterDefinition("PART_NAME")]
        //public SpecificationParameter ObjectName { get; set; } = new("Название объекта");

        //[ParameterDefinition("PART_SPECIALITY")]
        //public SpecificationParameter Specialty { get; set; } = new("");

        //[ParameterDefinition("PART_GROUP")]
        //public SpecificationParameter ProductGroup { get; set; } = new("Группа объекта");

        //[ParameterDefinition("PART_TYPE")]
        //public SpecificationParameter ProductType { get; set; } = new("Тип объекта");

        //[ParameterDefinition("PART_STATUS")]
        //public SpecificationParameter ProductStatus { get; set; } = new("Проектируемое");

        //[ParameterDefinition("BOM_COMMENT")]
        //public SpecificationParameter Notes { get; set; } = new("");

        //[ParameterDefinition("BOM_GROUP")]
        //public SpecificationParameter SpecificationGroup { get; set; } = new("");

        //[ParameterDefinition("BOM_INCLUDE")]
        //public SpecificationParameter IncludeInSpecification { get; set; } = new(1);

        //[ParameterDefinition("BOM_NUMBER")]
        //public SpecificationParameter SpecificationPosition { get; set; } = new("");

        //[ParameterDefinition("IFC_CLASS")]
        //public SpecificationParameter IfcClass { get; set; } = new("IfcClass");
    }
}
