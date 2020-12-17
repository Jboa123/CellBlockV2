using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace CellBlockV2Library.Initialisation
{
    public class GeneratePossibleBlocks
    {
        private ISolutionTracker _solutionTracker;
        private IPuzzleData _puzzleData;
        /// <summary>
        /// Multiple matrix of the current block dimensions set.
        /// </summary>
        private List<int> MultipleMatrix { get; set; }
        /// <summary>
        /// The set of block dimensions currently being processed.
        /// </summary>
        private List<int> DimensionSet { get; set; }
        /// <summary>
        /// The MainBlock currently being processed.
        /// </summary>
        private IMainBlock MainBlock{ get; set; }
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
        /// The index of the current dimension set in block dimension sets list in solution tracker.
        /// Directly used in the calculation of a possible block index.
        /// </summary>
        private int DimensionSetIndex { get; set; }
        /// <summary>
        /// The index of the dimenion that is currently being processed.
        /// </summary>
        private int DimensionIndex { get; set; }

        /// <summary>
        /// Loops though all MainBlocks within the Grid.
        /// Eventually adding all possible block indices to each Cell and MainBlock.
        /// </summary>
        private void ProcessAllMainBlocks()
        {
            foreach (IMainBlock mainBlock in _solutionTracker.Grid.MainBlocks)
            {
                MainBlock = mainBlock;
                ProcessMainBlocks();
            }
        }
        /// <summary>
        /// Considers a single MainBlock at a time.
        /// </summary>
        private void ProcessMainBlocks()
        {
            List<List<int>> BlockDimensionSets = _solutionTracker.BlockDimensionSets[MainBlock.Capacity];
            DimensionSetIndex = 0;
            while (DimensionSetIndex < BlockDimensionSets.Count)
            {
                //MultipleMatrix =
                DimensionSet = BlockDimensionSets[DimensionIndex];
                ProcessDimensionSet();
                DimensionSetIndex++;
            }
        }
        /// <summary>
        /// For a given MainBlock, all possible sets of dimensions are considered 1 at a time.
        /// </summary>
        private void ProcessDimensionSet()
        {
            //For the dimension set, 1 dimension is considered at a time starting with that of the highest index.
            int dimensionIndex = DimensionSet.Count - 1;
            //The algorith uses the Pre-defined Cell as the starting point.
            CurrentDimensionOfCells.Push(MainBlock.PreDefinedCell);

            while (DimensionIndex >= 0)
            {
                NextDimensionOfCells = new Stack<ICell>();
                NodeSepartion = MultipleMatrix[dimensionIndex + 1];
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
            int reach = DimensionSet[DimensionIndex] - 1;
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
                    if (outerCell.Instances.Peek().PossibleOwners.ContainsKey(MainBlock) == false)
                    {
                        outerCell.Instances.Peek().PossibleMainBlocks.AddLast(MainBlock);
                        outerCell.Instances.Peek().PossibleOwners.Add(MainBlock, GetCellPossilbeOwners(centralCell, offset));
                    }
                    else
                    {
                        foreach (int possibleOwner in GetCellPossilbeOwners(centralCell, offset))
                        {
                            outerCell.Instances.Peek().PossibleOwners[MainBlock].AddLast(possibleOwner);
                        }
                    }
                }
            }

            if (upperLimit != reach)
            {
                foreach (int possibleBlock in GetCellPossilbeOwners(MainBlock.PreDefinedCell, upperLimit + 1))
                {
                    MainBlock.Instances.Peek().PossibleBlocks.Remove(possibleBlock);
                }
                
            }

            if (lowerLimit != -reach)
            {
                foreach (int possibleBlock in GetCellPossilbeOwners(MainBlock.PreDefinedCell, lowerLimit - 1))
                {
                    MainBlock.Instances.Peek().PossibleBlocks.Remove(possibleBlock);
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
            int PBIndexToRemoveCount = Math.Abs(offset) * MultipleMatrix[DimensionIndex];
            //A Cell's possible owners is in the from dictionary<MainBlock, LinkedList<int>>.
            LinkedList<int> possibleOwners = new LinkedList<int>();
            //Loops though appropriate integers adding to the both the MainBlock's possible blocks and the Cell's possible owners


            LinkedListNode<int> centralCellPossibleOwner = centralCell.Instances.Peek().PossibleOwners[MainBlock].Last;
            LinkedList<int> outerCellPossibleOwners = new LinkedList<int>();
            int counter = 0;
            while (centralCellPossibleOwner.Value/(MainBlock.Capacity*DimensionIndex) >=1)
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
