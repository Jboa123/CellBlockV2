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
        public IMainBlock OwnedBy { get; set; }
        /// <summary>
        /// If OwnedBy != -1, this Cell is owned. If OwnedBy has a different value to that of the impuuted MainBlock then the cell is owned by a diffrernt MainBlock.
        /// Return true if both these condition are true, otherwise False.
        /// </summary>
        /// <param name="mainBlock"></param>
        /// <returns></returns>
        public bool IsOwnedByBlockOtherThan(IMainBlock mainBlock)
        {
            if (OwnedBy != null && OwnedBy != mainBlock)
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
            if (OwnedBy != null && OwnedBy != Grid.MainBlocks[mainBlockIndex])
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
            this.OwnedBy = mainBlock;
            mainBlock.Cells.Add(this);
            this.Grid.SolvedCellCount++;
        }

        public void SetOwnership(int mainBlockIndex)
        {
            IMainBlock mainBlock = this.Grid.MainBlocks[mainBlockIndex];
            this.OwnedBy = mainBlock;
            mainBlock.Cells.Add(this);
            this.Grid.SolvedCellCount++;
            this.RemoveImpossibleBlocksGlobally();
            /*this.PossibleOwners.Clear();
            this.PossibleOwners.Add(mainBlock, mainBlock.PossibleBlocks);*/
        }
        /// <summary>
        /// This method is designed to be called only from the SetOwnership method. Once a Cell is marked as onwed, all other PossibleBlocks of different index containing this Cell can be removed.
        /// All PossibleBlock corresponding to other MainBlocks can be removed.
        /// </summary>
        private void RemoveImpossibleBlocksGlobally()
        {
            foreach (var KVP in this.PossibleOwners)
            {
                IMainBlock mainBlock = KVP.Key;
                if (mainBlock != this.OwnedBy)
                {
                    foreach (var possibleBlock in KVP.Value)
                    {

                        mainBlock.PossibleBlocks.Remove(possibleBlock);
                        this.PossibleOwners[mainBlock].Remove(possibleBlock);

                    }
                }
            }
        }

    }
}
