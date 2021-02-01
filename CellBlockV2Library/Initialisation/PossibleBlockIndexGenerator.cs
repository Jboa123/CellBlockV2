using CellBlockV2Library.Possible_Block_Editing;
using CellBlockV2Library.Puzzle_Objects;
using CellBlockV2Library.Static_Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace CellBlockV2Library.Initialisation
{
    /// <summary>
    /// Calculates all the PossibleBlocks for the puzzle, adding the indices to the Cells and the MainBlocks.
    /// </summary>
    public class PossibleBlockIndexGenerator
    {
        private ISolutionTracker _solutionTracker;
        private IPuzzleData _puzzleData;
        private IOwnershipSetter _ownershipSetter;

        /// <summary>
        /// The MainBlock currently being processed.
        /// </summary>
        private IPossibleBlock PossibleBlock { get; set; }
        /// <summary>
        /// A layer of Cells being used to calculate the possible owners of adjacent Cells. 
        /// Each Cell in the stack is the central cell of the line (purpendicular to the layer) being processed.
        /// </summary>
        private Stack<ICell> CurrentDimensionOfCells { get; set; }
        /// <summary>
        /// The Cells that will be the layer of central Cells in the next dimension to be processed.
        /// Each cell processed in the CurrentDimensionOfCells is added to this stack.
        /// </summary>
        private Stack<ICell> NextDimensionOfCells { get; set; }
        /// <summary>
        /// Defined by the multiple matrix and the dimension index.
        /// </summary>
        private int NodeSepartion { get; set; }

        /// <summary>
        /// The index of the dimenion that is currently being processed.
        /// </summary>
        private int DimensionIndex { get; set; }

        /// <summary>
        /// Loops though all MainBlocks within the Grid.
        /// Eventually adding all possible block indices to each Cell and MainBlock.
        /// </summary>
        public void InitialisePossibleBlocks()
        {
            foreach (IMainBlock mainBlock in _solutionTracker.Grid.MainBlocks)
            {
                ProcessMainBlock(mainBlock);
            }

        }
        /// <summary>
        /// Considers a single MainBlock at a time.
        /// </summary>
        private void ProcessMainBlock(IMainBlock mainBlock)
        {
            int dimensionSetIndex = 0;
            while (dimensionSetIndex < _solutionTracker.BlockDimensionSets[mainBlock.Capacity].Count)
            {
                PossibleBlock = AdditionalMethods.CreatPossibleBlockFromDimensionSetIndex(mainBlock, _solutionTracker.BlockDimensionSets, dimensionSetIndex);
                ProcessDimensionSet();
                dimensionSetIndex++;
            }
        }
        /// <summary>
        /// For a given MainBlock, all possible sets of dimensions are considered 1 at a time.
        /// </summary>
        private void ProcessDimensionSet()
        {
            //For the dimension set, 1 dimension is considered at a time starting with that of the highest index.
            int dimensionIndex = PossibleBlock.DimensionSet.Count - 1;
            //The algorith uses the Pre-defined Cell as the starting point.
            CurrentDimensionOfCells.Push(PossibleBlock.MainBlock.PreDefinedCell);

            while (DimensionIndex >= 0)
            {
                NextDimensionOfCells = new Stack<ICell>();
                NodeSepartion = PossibleBlock.MultipleMatrix[dimensionIndex + 1];
                ProcessDimension();
                CurrentDimensionOfCells = NextDimensionOfCells;
                dimensionIndex--;
            }
        }
        /// <summary>
        /// Considers a single dimension for the given dimension set.
        /// </summary>
        private void ProcessDimension()
        {
            //A of length, l, has a reach of l-1 to eith side of the Pre-defined Cell whilst still containg the pre-defined Cell.
            int reach = PossibleBlock.DimensionSet[DimensionIndex] - 1;
            //The position of the layer of Cells in the dimension currently being processed.
            int position = CurrentDimensionOfCells.Peek().Coordinates[DimensionIndex];
            //The position of the outer most Cells in the Grid  in the current dimension.
            //Note the lower bound of the Grid is 0 by definition.
            int upperBound = _puzzleData.SideLengths[DimensionIndex]-1;
            //The limits are the distance between the PDC and Cell, of highest position, that need processing.
            //It is the reach of Block unless this extends beyond the bound of the Grid. In which case the upper limit is the distance between the PDC and the edge of the Grid.
            int upperLimit = reach - Math.Max(0, position + reach - upperBound);
            int lowerLimit = -reach - Math.Min(0, position - reach);
            //CurrentDimensionOfCells represents a layer of Cells. Each Cell in this layer is used to process a line of Cells purpendicular to the layer.
            foreach (ICell centralCell in CurrentDimensionOfCells)
            {
                for (int offset = lowerLimit; offset <= upperLimit; offset++)
                {
                    //Retrieves the Cell to be processed.
                    ICell outerCell = _solutionTracker.Grid.GetCellFromOffset(centralCell, DimensionIndex, offset);
                    NextDimensionOfCells.Push(outerCell);
                    if (outerCell.GetPossibleOwners.ContainsKey(PossibleBlock.MainBlock) == false)
                    {
                        outerCell.GetPossibleMainBlocks.AddLast(PossibleBlock.MainBlock);
                        outerCell.GetPossibleOwners.Add(PossibleBlock.MainBlock, GetCellPossilbeOwners(centralCell, offset));
                    }
                    else
                    {
                        foreach (int possibleOwner in GetCellPossilbeOwners(centralCell, offset))
                        {
                            outerCell.GetPossibleOwners[PossibleBlock.MainBlock].AddLast(possibleOwner);
                        }
                    }
                }
            }
            // Some PossibleBlocks are not possible as they extend beyond the bounds of the Grid.
            // These PossibleBlocks are removed.
            if (upperLimit != reach)
            {
                foreach (int possibleBlockIndex in GetCellPossilbeOwners(PossibleBlock.MainBlock.PreDefinedCell, upperLimit + 1))
                {
                    PossibleBlock.MainBlock.PossibleBlocks.Remove(possibleBlockIndex);
                }
                
            }

            if (lowerLimit != -reach)
            {
                foreach (int possibleBlockIndex in GetCellPossilbeOwners(PossibleBlock.MainBlock.PreDefinedCell, lowerLimit - 1))
                {
                    PossibleBlock.MainBlock.PossibleBlocks.Remove(possibleBlockIndex);
                }
                
            }
        }
        /// <summary>
        /// Considers a single Cell at time.
        /// </summary>
        /// <param name="centralCell"></param>
        /// <param name="offset"></param>
        private LinkedList<int> GetCellPossilbeOwners(ICell centralCell, int offset)
        {
            //The number of possible block indices to be added before or after each node for this Cell.
            int PBIndexToRemoveCount = Math.Abs(offset) * PossibleBlock.MultipleMatrix[DimensionIndex];
            //A Cell's possible owners is in the from dictionary<MainBlock, LinkedList<int>>.
            LinkedList<int> possibleOwners = new LinkedList<int>();
            //Loops though appropriate integers adding to the both the MainBlock's possible blocks and the Cell's possible owners
            LinkedListNode<int> centralCellPossibleOwner = centralCell.Instances.Peek().PossibleOwners[PossibleBlock.MainBlock].Last;
            LinkedList<int> outerCellPossibleOwners = new LinkedList<int>();
            //counts the number of PossibleBlocks that have been looped through.
            int counter = 0;
            while (centralCellPossibleOwner.Value/(PossibleBlock.MainBlock.Capacity*DimensionIndex) >=1)
            {
                if (offset < 0)
                {
                    if (counter % NodeSepartion > PBIndexToRemoveCount -1)
                    {
                        outerCellPossibleOwners.AddFirst(centralCellPossibleOwner.Value);
                    }
                }
                if (offset > 0)
                {
                    if (counter % NodeSepartion < NodeSepartion - PBIndexToRemoveCount)
                    {
                        outerCellPossibleOwners.AddFirst(centralCellPossibleOwner.Value);
                    }
                }
                centralCellPossibleOwner = centralCellPossibleOwner.Previous;
                counter++;
            }
            return outerCellPossibleOwners;
        }

        
    }
}
