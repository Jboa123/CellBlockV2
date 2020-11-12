using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    class Grid : IGrid
    {
        private IGridConversions _gridConversions;
        
        public List<ICell> Cells { get; set; }
        public List<IMainBlock> MainBlocks { get; set; }

        public ICell GetCellFromCartesian(List<int> cartesianCoordinates)
        {
            return (Cells[_gridConversions.CartesianToListPosition(cartesianCoordinates)]);
        }

    }
}
