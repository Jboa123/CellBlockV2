using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    class Grid : IGrid
    {
        public List<ICell> Cells { get; set; }
        public List<IMainBlock> MainBlocks { get; set; }
        public int SolvedCellCount { get; set; }
        public bool HasSolution
        {
            get
            {
                throw new NotImplementedException();
               /* if (SolvedCellCount == totalCapacity)
                {
                    return true;
                }
                else
                {
                    return false;
                }*/
            }
        }
    }
}
