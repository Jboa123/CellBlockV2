using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public class MainBlock : Block, IMainBlock
    {
        public MainBlock() : base() { }
        public MainBlock(int index, int area, ICell definedCell, IGrid grid) : base(index, area, definedCell, grid) { }
        public ICollection<IPossibleBlock> PossibleBlocks{ get; set; }
    }
}
