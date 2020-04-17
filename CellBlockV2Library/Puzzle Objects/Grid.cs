using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    class Grid : IGrid
    {
        public ICollection<ICell> Cells { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<IMainBlock> MainBlocks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SolvedCellCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool HasSolution { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
