using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Instance_Stack_Editing
{
    public class RemoveInstances : IRemoveInstances
    {
        private ISolutionTracker _solutionTracker;
        /// <summary>
        /// Loops through each Cell and MainBlock, removing the top Instance on the stack if the stack has a height equal to the max stack height of any of the set of stacks.
        /// </summary>
        public void RemoveTopInstances()
        {
            foreach (ICell cell in _solutionTracker.Grid.Cells)
            {
                if (cell.Instances.Count == _solutionTracker.Grid.MaxStackHeight)
                {
                    cell.Instances.Pop();
                }
            }

            foreach (IMainBlock mainBlock in _solutionTracker.Grid.MainBlocks)
            {
                if (mainBlock.Instances.Count == _solutionTracker.Grid.MaxStackHeight)
                {
                    mainBlock.Instances.Pop();
                    if (mainBlock.Solution != -1)
                    {
                        _solutionTracker.Grid.SolvedMainBlockCount--;
                    }
                }
            }
        }
    }
}
