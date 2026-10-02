using ParametricKit;
using ParametricKit.Primitives;
using ParametricKit.Primitives.Grips;

namespace ObjectLibrary.Table
{
    public class TableView2D : EntityView2D<Table>
    {
        public TableView2D(Table entity) : base(entity)
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
            // TODO: Add geometry initialization.
        }

        private void InitGrips()
        {
            // TODO: Add grips initialization. Or remove method if there are no grips.
        }
    }
}
