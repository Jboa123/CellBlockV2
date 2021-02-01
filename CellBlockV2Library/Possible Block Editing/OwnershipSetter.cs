using CellBlockV2Library.Puzzle_Objects;
using CellBlockV2Library.Static_Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Possible_Block_Editing
{

    public class OwnershipSetter : IOwnershipSetter
    {
        private IGetCellsFromIndex _getCellsFromIndex;
        private IPossibleBlockRemover _possibleBlockRemover;
        private ISolutionTracker _solutionTracker;
        public bool ChangeHasOccured { get; set; } = true;

        /// <summary>
        /// The solution OwnerMainBlock is set to the input possible block.
        /// Each Cell within the possible block is marked as owned.
        /// </summary>
        /// <param name="possibleBlock"></param>
        public bool SetPossibleBlockAsSolution(IPossibleBlock possibleBlock)
        {
            ChangeHasOccured = true;
            _solutionTracker.Grid.SolvedMainBlockCount++;
            foreach (ICell cell in _getCellsFromIndex.GetCells(possibleBlock))
            {
                if (cell.Owner == null)
                {
                    if(CheckMainBlocks(_possibleBlockRemover.RemoveImpossibleBlocks(cell, possibleBlock.MainBlock)))
                    {
                        return true;
                    }
                    cell.Owner = possibleBlock.MainBlock;
                }
            }
            possibleBlock.MainBlock.Solution = possibleBlock.Index;
            return false;
        }
        /// <summary>
        /// Marks the current Cell as owned by the current OwnerMainBlock, hence these properties need to be set correctly before calling this method.
        /// </summary>
        public bool MarkCellAsOwned(ICell cell, IMainBlock mainBlock)
        {
            ChangeHasOccured = true;
            if (CheckMainBlocks(_possibleBlockRemover.RemoveImpossibleBlocks(cell, mainBlock)))
            {
                return true;
            }
            _possibleBlockRemover.SetOwnerMainBlockPossibleBlocks(cell, mainBlock);
            cell.Owner = mainBlock;
            return false;
        }

        private bool CheckMainBlocks(List<IMainBlock> mainBlocks)
        {
            if (mainBlocks == null)
            {
                return true;
            }
            else
            {
                foreach (IMainBlock mainBlock in mainBlocks)
                {
                    foreach (int possibleBlock in mainBlock.PossibleBlocks)
                    {
                        SetPossibleBlockAsSolution(AdditionalMethods.CreatePossibleBlockFromIndex(mainBlock, _solutionTracker.BlockDimensionSets, possibleBlock));
                    }
                }
            }
            return false;
        }
    }
}
