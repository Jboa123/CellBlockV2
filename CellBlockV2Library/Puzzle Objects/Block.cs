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
        public Block(int index, int area, ICell definedCell, IGrid grid)
        {
            Index = index;
            Area = area;
            DefinedCell = definedCell;
            Grid = grid;
        }
        private IGrid Grid;
        public int Index { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Area { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICell DefinedCell { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<ICell> Cells { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICell TopLeftCell { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<int> Dimensions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
