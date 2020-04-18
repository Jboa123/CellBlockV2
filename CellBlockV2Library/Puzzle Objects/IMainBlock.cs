using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IMainBlock : IBlock
    {
        List<IPossibleBlock> PossibleBlocks { get; set; }
    }
}
