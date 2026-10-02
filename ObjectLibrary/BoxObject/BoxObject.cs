using ParametricKit;

namespace ObjectLibrary.BoxObject
{
    public class BoxObject : EntitySource<BoxObjectSpecification>
    {
        public BoxObjectView2D View2D { get; set; }
        public BoxObjectView3D View3D { get; set; }

        public BoxObject(BoxObjectSpecification specification) : base(specification)
        {
            View2D = new(this);
            View3D = new(this);
        }
    }
}
