using ParametricKit;
using ParametricKit.FunctionWizard;
using ParametricKit.Primitives;
using ParametricKit.Primitives.Grips;

namespace ObjectLibrary.Table
{
    public class TableView3D : EntityView3D<Table>
    {

        //Столешница
        public Box Top { get; set; }

        //Ножка круглого сечения - 4 штуки
        public Cylinder Leg1C { get; set; }
        public Cylinder Leg2C { get; set; }
        public Cylinder Leg3C { get; set; }
        public Cylinder Leg4C { get; set; }

        //Ножка квадратного сечения - 4 штуки
        public Box Leg1S { get; set; }
        public Box Leg2S { get; set; }
        public Box Leg3S { get; set; }
        public Box Leg4S { get; set; }

        // Ручки, много ручек

        // Длина столешницы
        public LengthGrip LengthTop { get; set; }
 
        // Ширина столешницы
        public LengthGrip WidghtTop { get; set; }

        // Уровень верхней плоскости столешницы
        public LengthGrip HeighTable { get; set; }
 
        //Толщина столешницы
        public LengthGrip ThickTop { get; set; }

        //Переключатель ножек
        public SwitchGrip CheckLegs { get; set; }

        //Сечение ножек
        public LengthGrip TableLegSizeCross { get; set; }

        // Смещение от края столешницы до ножки по оси X
        public OffsetGrip TableLegCrossX { get; set; }

        // Смещение от края столешницы до ножки по оси Y
        public OffsetGrip TableLegCrossY { get; set; }

        public TableView3D(Table entity) : base(entity)
        {
            InitVariables();
            InitGeometry();
            InitGrips();
        }

        private void InitVariables()
        {
            // TODO: Add variable initialization. Or remove method if there are no variables.
        }

        private void InitGeometry()
        {
            // Столешница - она же коробочка
            Top = new Box()
            {
                //SpecificationReference = Entity.Specification.ChildObject,

                Height = Entity.Specification.ThickTop,
                Length = Entity.Specification.LengthTop,
                Width = Entity.Specification.WidghtTop,

                BasePointX = Entity.Specification.PointX - Entity.Specification.LengthTop/2, 
                BasePointY = Entity.Specification.PointY - Entity.Specification.WidghtTop/2, 
                BasePointZ = Entity.Specification.PointZ + Entity.Specification.HeighTable -
                Entity.Specification.ThickTop,

            };

            // 4 циллиндрических ножки

            Leg1C = new Cylinder()
            {

                IsHidden = 1 - Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Radius = Entity.Specification.TableLegSizeCross / 2,
                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,

                BasePointX = Entity.Specification.PointX - 
                Entity.Specification.LengthTop / 2 + Entity.Specification.TableLegCrossX,

                BasePointY = Entity.Specification.PointY +
                Entity.Specification.WidghtTop / 2 - Entity.Specification.TableLegCrossY,

                BasePointZ = Entity.Specification.PointZ,
            };

            Leg2C = new Cylinder()
            {
                IsHidden = 1 - Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Radius = Entity.Specification.TableLegSizeCross / 2,
                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,

                BasePointX = Entity.Specification.PointX +
                Entity.Specification.LengthTop / 2 - Entity.Specification.TableLegCrossX,

                BasePointY = Entity.Specification.PointY +
                Entity.Specification.WidghtTop / 2 - Entity.Specification.TableLegCrossY,

                BasePointZ = Entity.Specification.PointZ,
            };
            
            Leg3C = new Cylinder()
            {
                IsHidden = 1- Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Radius = Entity.Specification.TableLegSizeCross / 2,
                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,

                BasePointX = Entity.Specification.PointX -
                Entity.Specification.LengthTop / 2 + Entity.Specification.TableLegCrossX,

                BasePointY = Entity.Specification.PointY -
                Entity.Specification.WidghtTop / 2 + Entity.Specification.TableLegCrossY,

                BasePointZ = Entity.Specification.PointZ,
            };

            Leg4C = new Cylinder()
            {
                IsHidden = 1 - Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Radius = Entity.Specification.TableLegSizeCross / 2,
                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,

                BasePointX = Entity.Specification.PointX +
                Entity.Specification.LengthTop / 2 - Entity.Specification.TableLegCrossX,

                BasePointY = Entity.Specification.PointY -
                Entity.Specification.WidghtTop / 2 + Entity.Specification.TableLegCrossY,

                BasePointZ = Entity.Specification.PointZ,
            };

            // 4 ножки - коробочки
            Leg1S = new Box()
            {
                IsHidden = Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,
                Length = Entity.Specification.TableLegSizeCross,
                Width = Entity.Specification.TableLegSizeCross,

                BasePointX = Entity.Specification.PointX -
                Entity.Specification.LengthTop / 2 + Entity.Specification.TableLegCrossX - 
                Entity.Specification.TableLegSizeCross / 2,

                BasePointY = Entity.Specification.PointY +
                Entity.Specification.WidghtTop / 2 - Entity.Specification.TableLegCrossY -
                Entity.Specification.TableLegSizeCross/2,

                BasePointZ = Entity.Specification.PointZ,
            };


            Leg2S = new Box()
            {
                IsHidden = Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,
                Length = Entity.Specification.TableLegSizeCross,
                Width = Entity.Specification.TableLegSizeCross,

                BasePointX = Entity.Specification.PointX +
                Entity.Specification.LengthTop / 2 - Entity.Specification.TableLegCrossX -
                Entity.Specification.TableLegSizeCross / 2,

                BasePointY = Entity.Specification.PointY +
                Entity.Specification.WidghtTop / 2 - Entity.Specification.TableLegCrossY -
                Entity.Specification.TableLegSizeCross / 2,

                BasePointZ = Entity.Specification.PointZ,
            };

            Leg3S = new Box()
            {
                IsHidden = Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,
                Length = Entity.Specification.TableLegSizeCross,
                Width = Entity.Specification.TableLegSizeCross,

                BasePointX = Entity.Specification.PointX -
                Entity.Specification.LengthTop / 2 + Entity.Specification.TableLegCrossX -
                Entity.Specification.TableLegSizeCross / 2,

                BasePointY = Entity.Specification.PointY -
                Entity.Specification.WidghtTop / 2 + Entity.Specification.TableLegCrossY -
                Entity.Specification.TableLegSizeCross / 2,

                BasePointZ = Entity.Specification.PointZ,
            };

            Leg4S = new Box()
            {
                IsHidden = Entity.Specification.CheckLegs,

                //SpecificationReference = Entity.Specification.ChildObject,

                Height = Entity.Specification.HeighTable - Entity.Specification.ThickTop,
                Length = Entity.Specification.TableLegSizeCross,
                Width = Entity.Specification.TableLegSizeCross,

                BasePointX = Entity.Specification.PointX +
                Entity.Specification.LengthTop / 2 - Entity.Specification.TableLegCrossX -
                Entity.Specification.TableLegSizeCross / 2,

                BasePointY = Entity.Specification.PointY -
                Entity.Specification.WidghtTop / 2 + Entity.Specification.TableLegCrossY -
                Entity.Specification.TableLegSizeCross / 2,

                BasePointZ = Entity.Specification.PointZ,
            };
        }

        private void InitGrips()
        {
            // TODO: Add grips initialization. Or remove method if there are no grips.
            CheckLegs = new SwitchGrip()
            {
                Name = "Сечение ножки",
                Assignment = Entity.Specification.CheckLegs,

                BasePointX = Entity.Specification.PointX + 100,
                BasePointY = Entity.Specification.PointY +100,
                BasePointZ = Entity.Specification.PointZ + Entity.Specification.HeighTable + 100,

                Tooltip = "Переключатель сечения ножки".AsLiteralExpression(),

                // Ограничения размера ножки


            };
            
            CheckLegs.AddValueVariant(new ValueVariant(0, "Квадратное"));

            CheckLegs.AddValueVariant(new ValueVariant(1, "Круглое"));

            LengthTop = new LengthGrip()
            {
                Name = "Длина",
                Assignment = Entity.Specification.LengthTop,
                DirectionX = 1,
                DirectionY = 0,
                DirectionZ = 0,

                BasePointX = Entity.Specification.PointX + Entity.Specification.LengthTop/2,
                BasePointY = Entity.Specification.PointY,
                BasePointZ = Entity.Specification.PointZ + Entity.Specification.HeighTable,

                Tooltip = "Длина столешницы".AsLiteralExpression(),
            };

            WidghtTop = new LengthGrip()
            {
                Name = "Ширина",
                Assignment = Entity.Specification.WidghtTop,
                DirectionX = 0,
                DirectionY = 1,
                DirectionZ = 0,

                BasePointX = Entity.Specification.PointX,
                BasePointY = Entity.Specification.PointY + Entity.Specification.WidghtTop / 2,
                BasePointZ = Entity.Specification.PointZ + Entity.Specification.HeighTable,

                Tooltip = "Ширина столешницы".AsLiteralExpression(),
            };

            HeighTable = new LengthGrip()
            {
                Name = "Высота",
                Assignment = Entity.Specification.HeighTable,
                DirectionX = 0,
                DirectionY = 0,
                DirectionZ = 1,

                BasePointX = Entity.Specification.PointX,
                BasePointY = Entity.Specification.PointY,
                BasePointZ = Entity.Specification.PointZ + Entity.Specification.HeighTable,

                Tooltip = "Выота стола".AsLiteralExpression(),
            };

            ThickTop = new LengthGrip()
            {
                Name = "Толщина столешницы",
                Assignment = Entity.Specification.ThickTop,
                DirectionX = 0,
                DirectionY = 0,
                DirectionZ = -1,

                BasePointX = Entity.Specification.PointX + Entity.Specification.LengthTop / 2,
                BasePointY = Entity.Specification.PointY + Entity.Specification.WidghtTop / 2,
                BasePointZ = Entity.Specification.PointZ + Entity.Specification.HeighTable,

                Tooltip = "Толщина столешницы".AsLiteralExpression(),
            };

            TableLegSizeCross = new LengthGrip()
            {
                Name = "Сечение ножки",
                Assignment = Entity.Specification.TableLegSizeCross,
                DirectionX = 1,
                DirectionY = 0,
                DirectionZ = 0,

                BasePointX = Entity.Specification.PointX +
                Entity.Specification.LengthTop / 2 - Entity.Specification.TableLegCrossX/2 + 
                Entity.Specification.TableLegSizeCross / 2,

                BasePointY = Entity.Specification.PointY +
                Entity.Specification.WidghtTop / 2 - Entity.Specification.TableLegCrossY/2,

                BasePointZ = Entity.Specification.PointZ,

                Tooltip = "Размер сечения ножки".AsLiteralExpression(),
            };

            TableLegCrossX = new OffsetGrip()
            {
                Name = "Смещение ножки по X",
                Assignment = Entity.Specification.TableLegCrossX,
                DirectionX = 1,
                DirectionY = 0,
                DirectionZ = 0,
                BasePointX = Entity.Specification.PointX -
                Entity.Specification.LengthTop / 2,
                BasePointY = Entity.Specification.PointY,
                BasePointZ = Entity.Specification.PointZ,
                Tooltip = "Смещение ножки по X".AsLiteralExpression(),
            };

            TableLegCrossY = new OffsetGrip()
            {
                Name = "Смещение ножки по Y",
                Assignment = Entity.Specification.TableLegCrossY,
                DirectionX = 0,
                DirectionY = 1,
                DirectionZ = 0,
                BasePointX = Entity.Specification.PointX,
                BasePointY = Entity.Specification.PointY -
                Entity.Specification.WidghtTop / 2,
                BasePointZ = Entity.Specification.PointZ,
                Tooltip = "Смещение ножки по Y".AsLiteralExpression(),
            };
        }
    }
}