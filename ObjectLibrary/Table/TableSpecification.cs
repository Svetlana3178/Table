using ParametricKit;
using ParametricKit.Attributes;
using ParametricKit.FunctionWizard;
using ParametricKit.Primitives;

namespace ObjectLibrary.Table
{

    public class TableSpecification : EntitySpecification
    {

        public TableSpecification()
        {
            Name = "Стол";
            //ChildObject = new();
        }
        //public ChildObjectSpecification ChildObject { get; set; }

        // Имя
        [ParameterDefinition("PART_NAME")]
        public SpecificationParameter ObjectName { get; set; } = new("Стол");

        // Все параметры по заданию

        // Точка вставки
        // Будем считать, что эта точка находится на нижнем уровне стола
        // в центре.

        // Координата точки вставки X
        [ParameterDefinition("POINT_X")]
        public SpecificationParameter PointX { get; set; } = 0;

        // Координата точки вставки Y
        [ParameterDefinition("POINT_Y")]
        public SpecificationParameter PointY { get; set; } = 0;

        // Координата точки вставки Z
        [ParameterDefinition("POINT_Z")]
        public SpecificationParameter PointZ { get; set; } = 0;
        // Длина столешницы
        [ParameterDefinition("DIM_LENGTH")]
        public SpecificationParameter LengthTop { get; set; } = 1400;

        // Ширина столешницы
        [ParameterDefinition("DIM_WIDTH")]
        public SpecificationParameter WidghtTop { get; set; } = 700;

        // Высота столешницы
        [ParameterDefinition("DIM_HEIGHT")]
        public SpecificationParameter HeighTable { get; set; } = 750;

        // Толщина столешницы
        [ParameterDefinition("DIM_THICK")]
        public SpecificationParameter ThickTop { get; set; } = 40;

        // Размер поперечного сечения ножек
        [ParameterDefinition("DIM_TL_SIZE_CROSS")]
        public SpecificationParameter TableLegSizeCross { get; set; } = 40;

        // Положение ножек - смещение от края по X
        [ParameterDefinition("DIM_TL_CROSS_X")]
        public SpecificationParameter TableLegCrossX { get; set; } = 80;

        // Положение ножек - смещение от края по Y
        [ParameterDefinition("DIM_TL_CROSS_Y")]
        public SpecificationParameter TableLegCrossY { get; set; } = 80;

        // Флаг выбора ножек: круглое сечение (false), квадратное сечение (true)
        [ParameterDefinition("CHECK_LEGS")]
        public SpecificationParameter CheckLegs { get; set; } = false;

        //public ChildObjectSpecification ChildObject { get; set; }

    }
}
