using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IBlock
    {
        int Index { get; set; }

        int Capacity { get; set; }

        ICell DefinedCell { get; set; }

        ICollection<ICell> Cells { get; set; }

        ICell TopLeftCell { get; set; }

        List<int> Dimensions { get; set; }
    }
}
