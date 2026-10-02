using ParametricKit;

namespace ObjectLibrary.Table
{
    public class Table : EntitySource<TableSpecification>
    {
        public TableView2D View2D { get; set; }
        public TableView3D View3D { get; set; }

        public Table(TableSpecification specification) : base(specification)
        {
            View2D = new(this);
            View3D = new(this);
        }
    }
}
