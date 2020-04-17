using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IGrid
    {
        ICollection<ICell> Cells { get; set; }
        ICollection<IMainBlock> MainBlocks { get; set; }
        int SolvedCellCount { get; set; }
        bool HasSolution { get; set; }
}
}
