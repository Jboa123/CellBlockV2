using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    public class CloneData : ICloneData
    {
        private ISolutionTracker _solutionTracker;

        /// <summary>
        /// Loops though each MainBlock and Cell adding a new instacne to any without a known solution.
        /// Copies relevant data from the original Instance on the stack.
        /// </summary>
        public void CloneInstancesAndData()
        {
            foreach (IMainBlock mainBlock in _solutionTracker.Grid.MainBlocks)
            {
                //No need to duplicate instance if it has a solution already.
                //Note: data will be added to the new instance when creating new Cell instances.
                if (mainBlock.Instances.Peek().SolutionIndex == -1)
                {
                    mainBlock.Instances.Push(new MainBlockInstance());
                }
            }

            foreach (ICell cell in _solutionTracker.Grid.Cells)
            {
                if (cell.Instances.Peek().OwnedBy == null)
                {
                    ICellInstance originalInstance = cell.Instances.Peek();
                    ICellInstance newInstance = new CellInstance();
                    cell.Instances.Push(newInstance);
                    CopyData(originalInstance, newInstance);
                }
            }
            _solutionTracker.Grid.MaxStackHeight++;
        }
        //For the given Cell, loops though each possible block for each possible MainBlock owner, adding the possible block to the new CellInstance and MainBlockInstace.
        //Note all the MainBlockInstances have already been created before this method is called.
        private void CopyData(ICellInstance originalInstance, ICellInstance newInstance)
        {
            foreach (IMainBlock mainBlock in originalInstance.PossibleMainBlocks)
            {
                LinkedList<int> possibleOwners = new LinkedList<int>();
                foreach (int possibleBlock in originalInstance.PossibleOwners[mainBlock])
                {
                    possibleOwners.AddLast(possibleBlock);
                    mainBlock.PossibleBlocks.Add(possibleBlock);
                }
                newInstance.PossibleOwners.Add(mainBlock, possibleOwners);
                newInstance.PossibleMainBlocks.AddLast(mainBlock);
            }
        }
    }
}
