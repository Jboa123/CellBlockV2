using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public class MainBlock : Block, IMainBlock
    {
        public MainBlock() : base() { }
        public MainBlock(int index, int capacity, ICell definedCell, IGrid grid) : base(index, capacity, definedCell, grid) { }
        public List<IPossibleBlock> PossibleBlocks{ get; set; }
    }
}
