using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    class PossibleBlockRemoval
    {
        ICell Cell { get; set; }
        public IMainBlock OwnerMainBlock { get; set; }
        public bool ProvesNoSolution { get; set; }
        
        /// <summary>
        /// For the given Cell, removes all of the Cell.PossibleOwners that are no longer valid by comparing to the the MainBlocks.PossilbeBlocks.
        /// </summary>
        private void RemoveInvalidPossibleBlocks()
        {

            LinkedListNode<IMainBlock> currentMainBlockNode = Cell.Instances.Peek().PossibleMainBlocks.First;
            while (currentMainBlockNode != null)
            {
                //Is MainBlock owned?
                if (currentMainBlockNode.Value.Instances.Peek().SolutionIndex != -1)
                {
                    Cell.Instances.Peek().PossibleOwners.Remove(currentMainBlockNode.Value);
                    Cell.Instances.Peek().PossibleMainBlocks.Remove(currentMainBlockNode);
                }
                else
                {

                    LinkedListNode<int> currentPossibleBlockNode = Cell.Instances.Peek().PossibleOwners[currentMainBlockNode.Value].First;
                    while (currentPossibleBlockNode != null)
                    {
                        if (currentMainBlockNode.Value.Instances.Peek().PossibleBlocks.Contains(currentPossibleBlockNode.Value) == false)
                        {
                            Cell.Instances.Peek().PossibleOwners[currentMainBlockNode.Value].Remove(currentPossibleBlockNode);
                        }
                        currentPossibleBlockNode = currentPossibleBlockNode.Next;
                    }
                    //If the Cell no longer has PossibleOwners for a MainBlock, the MainBlock is removed from the Cell.PossibleOwners.
                    if (Cell.Instances.Peek().PossibleOwners[currentMainBlockNode.Value].Count == 0)
                    {
                        Cell.Instances.Peek().PossibleOwners.Remove(currentMainBlockNode.Value);
                        Cell.Instances.Peek().PossibleMainBlocks.Remove(currentMainBlockNode);
                    }
                }
                currentMainBlockNode = currentMainBlockNode.Next;
            }

        }
        /// <summary>
        /// Check the number of MainBlocks that may own the given Cell.
        /// Can proves no solution, mark a Cell as owned or set a possible block as a solution to a MainBlock.
        /// </summary>
        private void CountCellPossibleOwners()
        {
            if (Cell.Instances.Peek().PossibleMainBlocks.Count == 0)
            {
                ProvesNoSolution = true;
            }
            if (Cell.Instances.Peek().PossibleMainBlocks.Count == 1)
            {
                if (Cell.Instances.Peek().PossibleOwners[Cell.Instances.Peek().PossibleMainBlocks.First.Value].Count == 1)
                {
                    SetPossibleBlockAsSolution(Cell.Instances.Peek().PossibleOwners[Cell.Instances.Peek().PossibleMainBlocks.First.Value].First.Value);
                }
                else
                {
                    MarkCellAsOwned();
                }
            }

        }
        /// <summary>
        /// Compare the number of the Cell.PossibleOwners for a MainBlock to the number of MainBlock.PossibleBlocks. If the number is the same, the MainBlock requires that Cell to have a solution.
        /// If this occurs once for the Cell -> mark the Cll as owned.
        /// If this occurs more that once, multiple MainBlocks require the Cell for a solution, hence no solution is possible.
        /// </summary>
        private void CompareCellToMainBlock()
        {
            LinkedListNode<IMainBlock> currentMainBlockNode = Cell.Instances.Peek().PossibleMainBlocks.First;
            int counter = 0;
            while (currentMainBlockNode != null)
            {
                if (Cell.Instances.Peek().PossibleOwners[currentMainBlockNode.Value].Count == currentMainBlockNode.Value.Instances.Peek().PossibleBlocks.Count)
                {
                    //Keep a reference to the last MainBlock that fulfillied the criteria, will be used f the count is 1.
                    OwnerMainBlock = currentMainBlockNode.Value;
                    counter++;
                }
                currentMainBlockNode = currentMainBlockNode.Next;
            }
            if (counter == 1)
            {
                MarkCellAsOwned();
            }
            if (counter > 1)
            {
                ProvesNoSolution = true;
            }
        }
        /// <summary>
        /// The solution OwnerMainBlock is set to the input possible block.
        /// Each Cell within the possible block is marked as owned.
        /// </summary>
        /// <param name="possibleBlock"></param>
        public void SetPossibleBlockAsSolution(int possibleBlock)
        {
            foreach (ICell cell in GetCellsFromIndex(possibleBlock, OwnerMainBlock))
            {
                if (cell.Instances.Peek().OwnedBy == null)
                {
                    Cell = cell;
                    RemoveImpossibleBlocks();
                    Cell.Instances.Peek().OwnedBy = OwnerMainBlock;
                }
            }
            OwnerMainBlock.Instances.Peek().SolutionIndex = possibleBlock;
            OwnerMainBlock.Instances.Peek().PossibleBlocks.Clear();
        }
        /// <summary>
        /// Marks the current Cell as owned by the current OwnerMainBlock, hence these properties need to be set correctly before calling this method.
        /// </summary>
        public void MarkCellAsOwned()
        {
            Cell.Instances.Peek().OwnedBy = OwnerMainBlock;
            SetOwnerMainBlockPossibleBlocks();
            RemoveImpossibleBlocks();
            Cell.Instances.Peek().PossibleMainBlocks.Clear();
            Cell.Instances.Peek().PossibleOwners.Clear();
        }
        /// <summary>
        /// For the current Cell, loops though the PossibleOwners removing each value from the respective MainBlock.PossibleBlocks, except the OwnerMainBlock.
        /// If MainBlock.PossibleBlocks is empty there cannot be a solution. If it contains 1 value, this must be the solution to the MainBlock.
        /// </summary>
        private void RemoveImpossibleBlocks()
        {
            LinkedListNode<IMainBlock> CurrentMainBlockNode = Cell.Instances.Peek().PossibleMainBlocks.First;
            while (CurrentMainBlockNode != null)
            {
                if (OwnerMainBlock != CurrentMainBlockNode.Value)
                {
                    foreach (int possibleBlock in Cell.Instances.Peek().PossibleOwners[CurrentMainBlockNode.Value])
                    {
                        CurrentMainBlockNode.Value.Instances.Peek().PossibleBlocks.Remove(possibleBlock);
                    }
                    if (CurrentMainBlockNode.Value.Instances.Peek().PossibleBlocks.Count == 0)
                    {
                        ProvesNoSolution = true;
                    }
                    else if (CurrentMainBlockNode.Value.Instances.Peek().PossibleBlocks.Count == 1)
                    {
                        OwnerMainBlock = CurrentMainBlockNode.Value;
                        foreach (int possibleBlock in CurrentMainBlockNode.Value.Instances.Peek().PossibleBlocks)
                        {
                            SetPossibleBlockAsSolution(possibleBlock);
                        }
                    }
                }
                CurrentMainBlockNode = CurrentMainBlockNode.Next;
            }
        }
        /// <summary>
        /// When the current Cell is marked as owned, only the possible blocks that contain this cell are valid.
        /// The MainBlock.PossibleBlock is updated accordingly.
        /// </summary>
        private void SetOwnerMainBlockPossibleBlocks()
        {
            HashSet<int> possibleBlocks = new HashSet<int>();

            foreach (int possibleBlock in Cell.Instances.Peek().PossibleOwners[OwnerMainBlock])
            {
                possibleBlocks.Add(possibleBlock);
            }

            OwnerMainBlock.Instances.Peek().PossibleBlocks = possibleBlocks;
        }
    }
}
