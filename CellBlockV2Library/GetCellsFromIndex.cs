using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    /// <summary>
    /// Used to calculate the Cells 
    /// </summary>
    public class GetCellsFromIndex : IGetCellsFromIndex
    {

        private ISolutionTracker _solutionTracker;

        /// <summary>
        /// Returns all the Cells contained within a specific PossibleBlock.
        /// </summary>
        /// <param name="possibleBlock"></param>
        /// <returns></returns>
        public List<ICell> GetCells(IPossibleBlock possibleBlock)
        {
            //The Cells are retrieved a layer at a time. Starting from the PreDefinedCell a 1 dimensional layer (line) is calculated.
            //Using each Cell in this layer, the next, 2 dimensional layer (plane) of Cells is calculated and so on. 
            //Note each Cell has the same coordinate in the current dimension
            Stack<ICell> currentLayerOfCells = new Stack<ICell>();
            currentLayerOfCells.Push(possibleBlock.MainBlock.PreDefinedCell);
            //The PossibleBlock.Index defines the Cells contained within the Block.
            int blockIndexRemainer = possibleBlock.Index % possibleBlock.MainBlock.Capacity;
            //Starts with the dimension of highest index, working towards the first dimension (index 0).
            int dimensionIndex = possibleBlock.DimensionSet.Count - 1;
            while (dimensionIndex >= 0)
            {
                currentLayerOfCells = GetDimensionOfCells(currentLayerOfCells, possibleBlock, dimensionIndex, blockIndexRemainer);
                //Specific partitions of the PossibleBlock.Index define the blocks position in each dimension.
                blockIndexRemainer = blockIndexRemainer % possibleBlock.MultipleMatrix[dimensionIndex] - (possibleBlock.DimensionSet[dimensionIndex] - 1);
                dimensionIndex--;
            }
            return possibleBlock.Cells;
        }

        private Stack<ICell> GetDimensionOfCells(Stack<ICell> currentLayerOfCells, IPossibleBlock possibleBlock, int dimensionIndex, int blockIndexRemainer)
        {
            Stack<ICell> nextLayerOfCells = new Stack<ICell>();
            //For the current dimension, the lowerLimit is the distance between the layer of Cells and the Cells with the lowest coordinate value.
            //Hence the loop, lowerLimit -> lowerLimit + blockLength, gets the relative position of each Cell in the next layer.
            int lowerLimit = blockIndexRemainer / possibleBlock.MultipleMatrix[dimensionIndex] - (possibleBlock.DimensionSet[dimensionIndex] - 1);
            foreach (ICell cell in currentLayerOfCells)
            {
                for (int i = lowerLimit; i <= lowerLimit + possibleBlock.DimensionSet[dimensionIndex]; i++)
                {
                    ICell adjacentCell = _solutionTracker.Grid.GetCellFromOffset(cell, dimensionIndex, i);
                    nextLayerOfCells.Push(adjacentCell);
                    //Only add the Cells to the complete list on the final iteration to avoid any duplicates.
                    if (dimensionIndex == 0)
                    {
                        possibleBlock.Cells.Add(adjacentCell);
                    }

                }
            }
            return nextLayerOfCells;
        }

    }
}
