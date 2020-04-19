using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public class PossibleBlock : Block, IPossibleBlock
    {
        public PossibleBlock() : base() { }
        public PossibleBlock(int index, int capacity, ICell definedCell, IGrid grid) : base(index, capacity, definedCell, grid) { }
        /// <summary>
        /// Sets the relevant properties of the appropriate MainBlock to those of this PossibleBlock.
        /// </summary>
        public void SetAsMainBlock()
        {
            IMainBlock mainBlock = this.Grid.MainBlocks[this.Index];
            mainBlock.Cells = this.Cells;
            mainBlock.TopLeftCell = this.TopLeftCell;
            mainBlock.Dimensions = this.Dimensions;
            mainBlock.PossibleBlocks.Clear();
            mainBlock.PossibleBlocks.Add(this);
            foreach (ICell cell in this.Cells)
            {
                if (cell.OwnedBy == null)
                {
                    cell.SetOwnership(mainBlock);
                }
            }
        }
    }
}
