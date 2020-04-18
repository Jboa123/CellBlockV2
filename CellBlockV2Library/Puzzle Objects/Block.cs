using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public abstract class Block:IBlock
    {
        public Block()
        {

        }
        /// <summary>
        /// Contructor with all properties that are know from the start.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="area"></param>
        /// <param name="definedCell"></param>
        /// <param name="grid"></param>
        public Block(int index, int capacity, ICell definedCell, IGrid grid)
        {
            this.Index = index;
            this.Capacity = capacity;
            this.DefinedCell = definedCell;
            this.Grid = grid;
        }
        protected IGrid Grid;
        public int Index { get; set; }
        public int Capacity { get; set; }
        public ICell DefinedCell { get; set; }
        /// <summary>
        /// The Collection of Cells that make up the block.
        /// Not initially known for MainBlocks. Always known for Possible Block.
        /// </summary>
        public ICollection<ICell> Cells { get; set; }
        /// <summary>
        ///  Not initially known for MainBlocks. Always known for Possible Block.
        ///  The coordinates of the Cell of MainBlocks are used when saving the solution to a data base.
        /// </summary>
        public ICell TopLeftCell { get; set; }
        /// <summary>
        /// Not initially known for MainBlocks. Always known for Possible Block.
        ///  The coordinates of the Cell of MainBlocks are used when saving the solution to a data base.
        /// </summary>
        public List<int> Dimensions { get; set; }
    }
}
