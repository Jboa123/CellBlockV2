using CellBlockV2Library.Possible_Block_Editing;
using CellBlockV2Library.Puzzle_Objects;
using CellBlockV2Library.Static_Methods;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace CellBlockV2Library
{

    public class PossibleOwnerEditor : IPossibleOwnerEditor
    {

        private ISolutionTracker _solutionTracker;
        private IOwnershipSetter _ownershipSetter;


        public bool CheckAllCells()
        {
            _ownershipSetter.ChangeHasOccured = false;
            foreach (ICell cell in _solutionTracker.Grid.Cells)
            {
                if (cell.Owner == null)
                {
                    RemoveInvalidPossibleOwners(cell);
                    if (CountCellPossibleOwners(cell))
                    {
                        return true;
                    }
                    if (CompareCellToMainBlock(cell))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// For the given Cell, removes all of the Cell.PossibleOwners that are no longer valid by comparing to the the MainBlocks.PossilbeBlocks.
        /// </summary>
        private void RemoveInvalidPossibleOwners(ICell cell)
        {

            LinkedListNode<IMainBlock> currentMainBlockNode = cell.GetPossibleMainBlocks.First;
            while (currentMainBlockNode != null)
            {
                //If the MainBlock has a solution already, it cannot contain this Cell.
                //All Cells in the MainBlock will have been marked as owned and this method is not called for owned Cells.
                if (currentMainBlockNode.Value.Solution != -1)
                {
                    cell.GetPossibleOwners.Remove(currentMainBlockNode.Value);
                    cell.GetPossibleMainBlocks.Remove(currentMainBlockNode);
                }
                else
                {
                    LinkedListNode<int> currentPossibleBlockNode = cell.GetPossibleOwners[currentMainBlockNode.Value].First;
                    while (currentPossibleBlockNode != null)
                    {
                        if (currentMainBlockNode.Value.PossibleBlocks.Contains(currentPossibleBlockNode.Value) == false)
                        {
                            cell.GetPossibleOwners[currentMainBlockNode.Value].Remove(currentPossibleBlockNode);
                        }
                        currentPossibleBlockNode = currentPossibleBlockNode.Next;
                    }
                    //If the Cell no longer has PossibleOwners for a MainBlock, the MainBlock is removed from the Cell.PossibleOwners.
                    if (cell.GetPossibleOwners[currentMainBlockNode.Value].Count == 0)
                    {
                        cell.GetPossibleOwners.Remove(currentMainBlockNode.Value);
                        cell.GetPossibleMainBlocks.Remove(currentMainBlockNode);
                    }
                }
                currentMainBlockNode = currentMainBlockNode.Next;
            }
        }
        /// <summary>
        /// Check the number of MainBlocks that may own the given Cell.
        /// Can proves no solution, mark a Cell as owned or set a possible block as a solution to a MainBlock.
        /// </summary>
        private bool CountCellPossibleOwners(ICell cell)
        {
            //There are no MainBlocks that can contain the Cell, hence there can be no solution.
            if (cell.GetPossibleMainBlocks.Count == 0)
            {
                return true;
            }
            //There is only 1 MainBlock that can contain this Cell, hence the Cell must be owned by said MainBlock.
            //If there is also only 1 PossibleOwner for this MainBlock, that PossibleBlock must be the solution to the MainBlock.
            if (cell.GetPossibleMainBlocks.Count == 1)
            {

                if (cell.GetPossibleOwners[cell.GetPossibleMainBlocks.First.Value].Count == 1)
                {
                    if (_ownershipSetter.SetPossibleBlockAsSolution(AdditionalMethods.CreatePossibleBlockFromIndex(
                        cell.GetPossibleMainBlocks.First.Value, _solutionTracker.BlockDimensionSets, cell.GetPossibleOwners[cell.GetPossibleMainBlocks.First.Value].First.Value)))
                    {
                        return true;
                    }
                }
                else
                {
                    if (_ownershipSetter.MarkCellAsOwned(cell, cell.GetPossibleMainBlocks.First.Value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Compare the number of the Cell.PossibleOwners for a MainBlock to the number of MainBlock.PossibleBlocks. If the number is the same, the MainBlock requires that Cell to have a solution.
        /// If this occurs once for the Cell -> mark the Cell as owned.
        /// If this occurs more that once, multiple MainBlocks require the Cell for a solution, hence no solution is possible.
        /// </summary>
        private bool CompareCellToMainBlock(ICell cell)
        {
            LinkedListNode<IMainBlock> currentMainBlockNode = cell.GetPossibleMainBlocks.First;
            int counter = 0;
            IMainBlock BlockRequringCell = null;
            while (currentMainBlockNode != null)
            {
                if (cell.GetPossibleOwners[currentMainBlockNode.Value].Count == currentMainBlockNode.Value.PossibleBlocks.Count)
                {
                    //Keep a reference to the last MainBlock that fulfilled the criteria, will be used if the count is 1.
                    BlockRequringCell = currentMainBlockNode.Value;
                    counter++;
                }
                currentMainBlockNode = currentMainBlockNode.Next;
            }
            if (counter == 1)
            {
                if (_ownershipSetter.MarkCellAsOwned(cell, BlockRequringCell) == true)
                {
                    return true;
                }
            }
            if (counter > 1)
            {
                return true;
            }
            return false;
        }
    }
}
