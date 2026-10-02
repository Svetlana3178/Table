using ParametricKit;
using ParametricKit.Primitives;
using ParametricKit.Primitives.Grips;

namespace ObjectLibrary.BoxObject
{
    public class BoxObjectView3D : EntityView3D<BoxObject>
    {
        public Box Box { get; set; }

        public LengthGrip LengthGrip { get; set; }

        public LengthGrip WidthGrip { get; set; }

        public LengthGrip HeightGrip { get; set; }

        public BoxObjectView3D(BoxObject entity) : base(entity)
        {
            //InitVariables();
            InitGeometry();
            InitGrips();
        }

        //private void InitVariables()
        //{
        //    // TODO: Add variable initialization. Or remove method if there are no variables.
        //}

        private void InitGeometry()
        {
            Box = new Box()
            {
                SpecificationReference = Entity.Specification.ChildObject,

                Height = Entity.Specification.Height,
                Length = Entity.Specification.Lenght,
                Width = Entity.Specification.Width,

                BasePointX = -Entity.Specification.Lenght / 2,
                BasePointY = -Entity.Specification.Width / 2,
                BasePointZ = -Entity.Specification.Height/2,
            };
            // TODO: Add geometry initialization. You can use Entity.Specification property for access to specification.
        }

        private void InitGrips()
        {
            // TODO: Add grips initialization. Or remove method if there are no grips.
            LengthGrip = new LengthGrip()
            {
                Name = "Длина",
                DirectionX = 1,
                DirectionY = 0,
                DirectionZ = 0,
                BasePointX = -Entity.Specification.Lenght / 2,
                Assignment = Entity.Specification.Lenght,
                Position = Entity.Specification.Lenght,
            };

            WidthGrip = new LengthGrip()
            {
                Name = "Ширина",
                DirectionX = 0,
                DirectionY = 1,
                DirectionZ = 0,
                BasePointY = -Entity.Specification.Width / 2,
                Assignment = Entity.Specification.Width,
                Position = Entity.Specification.Width,
            };

            HeightGrip = new LengthGrip()
            {
                Name = "Высота",
                DirectionX = 0,
                DirectionY = 0,
                DirectionZ = 1,
                BasePointY = -Entity.Specification.Height / 2,
                Assignment = Entity.Specification.Height,
                Position = Entity.Specification.Height,
            };

        }
    }
}