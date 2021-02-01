using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Possible_Block_Editing
{
    public class PossibleBlockRemover : IPossibleBlockRemover
    {

        /// <summary>
        /// For the current Cell, loops though the PossibleOwners removing each value from the respective MainBlock.PossibleBlocks, except the OwnerMainBlock.
        /// </summary>
        public List<IMainBlock> RemoveImpossibleBlocks(ICell cell, IMainBlock mainBlock)
        {
            LinkedListNode<IMainBlock> CurrentMainBlockNode = cell.GetPossibleMainBlocks.First;
            List<IMainBlock> MainBlocksWithOnePossibleBlock = new List<IMainBlock>();
            while (CurrentMainBlockNode != null)
            {
                if (mainBlock != CurrentMainBlockNode.Value)
                {
                    foreach (int possibleBlock in cell.GetPossibleOwners[CurrentMainBlockNode.Value])
                    {
                        CurrentMainBlockNode.Value.PossibleBlocks.Remove(possibleBlock);
                    }
                    if (CurrentMainBlockNode.Value.PossibleBlocks.Count == 0)
                    {
                        return null;
                    }
                    else if (CurrentMainBlockNode.Value.PossibleBlocks.Count == 1)
                    {
                        MainBlocksWithOnePossibleBlock.Add(CurrentMainBlockNode.Value);
                    }
                }
                CurrentMainBlockNode = CurrentMainBlockNode.Next;
            }
            return MainBlocksWithOnePossibleBlock;
        }
        /// <summary>
        /// When the current Cell is marked as owned, only the possible blocks that contain this cell are valid.
        /// The MainBlock.PossibleBlock is updated accordingly.
        /// </summary>
        public void SetOwnerMainBlockPossibleBlocks(ICell cell, IMainBlock mainBlock)
        {
            HashSet<int> possibleBlocks = new HashSet<int>();

            foreach (int possibleBlock in cell.GetPossibleOwners[cell.Owner])
            {
                possibleBlocks.Add(possibleBlock);
            }

            mainBlock.PossibleBlocks = possibleBlocks;
        }
    }
}

