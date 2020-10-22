using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Iterations
{
    public class RemovePossibleBlocks
    {

        public IGrid Grid { get; set; }
        public bool ProvesNoSolution { get; set; }
        public bool ChangeHasOccurred { get; set; }

        private void RemoveCellImpossibleBlocks(ICell cell)
        {
            this.RemoveNonExistantPossibleBlocks(cell);
            //If no PossibleBlocks contain this Cell, this Cell has no possible owner hence the grid has no solution
            if(cell.PossibleOwners.Count == 0)
            {
                this.ProvesNoSolution = true;
            }

            //Tracks the MainBlocks that must contain this cell. If the count is >1, there is no solution to this instance of the Grid as 2 MainBlocks require this Cell for completion.
            //If the count = 1, the Cell must be owned by the corresponding MainBlock, provided this Grid instance has a solution.
            //If 0, no further information is gathered.
            List<IMainBlock> mainBlocksThatMustContain = GetMainBlockThatMustContain(cell);

            if (mainBlocksThatMustContain.Count > 1)
            {
                ProvesNoSolution = true;
            }
            else if(mainBlocksThatMustContain.Count ==1)
            {
                IMainBlock mainBlock = mainBlocksThatMustContain[0];
                List<IPossibleBlock> possibleBlocks = cell.PossibleOwners[mainBlock];
                //If there is only 1 PossibleBlock that contains this Cell -> the PossibleBlock must be a MainBlock. 
                //If there is multiple PossibleBlocks but all correspond to a single MainBlock-> this Cell must be owned by that MainBlock.
                if(possibleBlocks.Count == 1)
                {
                    this.ProvesNoSolution = possibleBlocks[0].SetAsMainBlock();
                }else
                {
                    this.ProvesNoSolution =  cell.SetOwnership(mainBlock);
                }

            }
        }
        /// <summary>
        /// Loops through all Keys(MainBlock) in Cell.PossibleOwners. Adding all MainBlocks that require ownership of this cell to a list and returning the list.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private List<IMainBlock> GetMainBlockThatMustContain(ICell cell)
        {
            List<IMainBlock> mainBlocksThatMustContain = new List<IMainBlock>();
            foreach (KeyValuePair<IMainBlock, List<IPossibleBlock>> KVP in cell.PossibleOwners)
            {
                IMainBlock mainBlock = KVP.Key;

                if (this.CellIsSubsetOfAllPossibleBlocks(cell, mainBlock) || cell.PossibleOwners.Count ==1)
                {
                    mainBlocksThatMustContain.Add(mainBlock);
                }
            }
            return mainBlocksThatMustContain;
        }

        /// <summary>
        /// Is the input Cell a member of all PossibleBlocks for the input MainBlock? Return true if so, else return false.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="mainBlock"></param>
        /// <returns></returns>
        private bool CellIsSubsetOfAllPossibleBlocks(ICell cell, IMainBlock mainBlock)
        {
            if (mainBlock.PossibleBlocks.Count == cell.PossibleOwners[mainBlock].Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


       /// <summary>
       /// Loops through each PossibleOwner for the input Cell and removes it if it no longer exists.
       /// Each PossibleBlock is check to see if it exists in the the appropriate MainBlock.PossibleBlocks
       /// </summary>
       /// <param name="cell"></param>
        private void RemoveNonExistantPossibleBlocks(ICell cell)
        {
            foreach (KeyValuePair<IMainBlock, List<IPossibleBlock>> KVP in cell.PossibleOwners)
            {
                IMainBlock mainBlock = KVP.Key;
                //This list keeps track of the PossibleBlocks that still exist.
                List<IPossibleBlock> updatedPossibleBlocks = new List<IPossibleBlock>();
                foreach (IPossibleBlock possibleBlock in KVP.Value)
                {
                    if(mainBlock.PossibleBlocks.Contains(possibleBlock))
                    {
                        updatedPossibleBlocks.Add(possibleBlock);
                    }
                }
                //Remove the key from the dictionary and re-add the same key with the updated PossibleBlock list (value) provided it is not empty.              
                cell.PossibleOwners.Remove(mainBlock);
                if (updatedPossibleBlocks.Count != 0)
                {
                    cell.PossibleOwners.Add(mainBlock, updatedPossibleBlocks);
                }
                //Alternate options are: Clear the list and append the new list to empty list; Track the elements to remove and removed the individually after the inital loop.

            }


        }
    }
}
