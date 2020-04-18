using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace CellBlockV2Library.Puzzle_Objects
{
    class Cell : ICell
    {
        private IGrid Grid;
        public Dictionary<IMainBlock, List<IPossibleBlock>> PossibleOwners { get; set; }
        public List<int> Coordinates { get; set ; }
        public int OwnedBy { get; set; }
        /// <summary>
        /// If OwnedBy != -1, this Cell is owned. If OwnedBy has a different value to that of the impuuted MainBlock then the cell is owned by a diffrernt MainBlock.
        /// Return true if both these condition are true, otherwise False.
        /// </summary>
        /// <param name="mainBlock"></param>
        /// <returns></returns>
        public bool IsOwnedByBlockOtherThan(IMainBlock mainBlock)
        {
            if (OwnedBy !=1 && OwnedBy != mainBlock.Index)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOwnedByBlockOtherThan(int mainBlockIndex)
        {
            if (OwnedBy != 1 && OwnedBy != mainBlockIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Add this Cell to the relevant MainBlocks Cells as it now must be a member.
        /// Increments SolvedCellCount which is used to test if a given instance of a Grid has been solved.
        /// </summary>
        /// <param name="mainBlock"></param>
        public void SetOwnership(IMainBlock mainBlock)
        { 
            this.OwnedBy = mainBlock.Index;
            mainBlock.Cells.Add(this);
            this.Grid.SolvedCellCount++;
        }

        public void SetOwnership(int mainBlockIndex)
        {
            IMainBlock mainBlock = this.Grid.MainBlocks[mainBlockIndex];
            this.OwnedBy = mainBlockIndex;
            mainBlock.Cells.Add(this);
            this.Grid.SolvedCellCount++;
            this.PossibleOwners.Clear();
            this.PossibleOwners.Add(mainBlock, mainBlock.PossibleBlocks);
        }
    }
}
