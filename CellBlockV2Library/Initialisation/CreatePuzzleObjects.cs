using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    /// <summary>
    /// Creates the Grid, Cells and MainBlocks.
    /// </summary>
    public class CreatePuzzleObjects : ICreatePuzzleObjects
    {
        public CreatePuzzleObjects()
        {
            CreateCells();
            CreateMainBlocks();
        }
        public IPuzzleData _puzzleData { get; set; }
        public ISolutionTracker _solutionTracker { get; set; }
        /// <summary>
        /// Create all cells within the Grid, based on the Grid's side lengths, specified by the user.
        /// </summary>
        private void CreateCells()
        {
            for (int i = 0; i < GetCapacity(); i++)
            {
                ICell cell = new Cell(GetCoordinatesFromLinearPosition(i));
                _solutionTracker.Grid.Cells.Add(cell);
            }
        }
        /// <summary>
        /// Creates all the MainBlocks for the puzzle based on all the PreDefinedCells given by the user.
        /// </summary>
        private void CreateMainBlocks()
        {
            for (int i = 0; i < _puzzleData.PreDefinedCells.Count; i++)
            {
                IMainBlock mainBlock = new MainBlock(_puzzleData.PreDefinedCells[i].Value, _solutionTracker.Grid.GetCellFromCoordinates(_puzzleData.PreDefinedCells[i].Coordinates), i);
                _solutionTracker.Grid.MainBlocks.Add(mainBlock);
            }
        }

        /// <summary>
        /// The total number of cells contained within the Grid.
        /// </summary>
        private int GetCapacity()
        {
            //Multiply each side length to calculate total capacity.
            int capacity = 1;
            foreach (int length in _puzzleData.SideLengths)
            {
                capacity *= length;
            }
            return capacity;

        }
        /// <summary>
        /// Returns the the coordinates of the Cell which has the specified index in the Grid.Cells list.
        /// </summary>
        /// <param name="linearPosition"></param>
        /// <returns></returns>
        private List<int> GetCoordinatesFromLinearPosition(int linearPosition)
        {
            //Cooridinates are calcluated in reverse order.
            List<int> reverseCoordinates = new List<int>();

            for (int i = _puzzleData.SideLengths.Count; i >= 0; i--)
            {
                reverseCoordinates.Add(linearPosition / _solutionTracker.Grid.MultipleMaxtrix[i]);
                linearPosition %= _solutionTracker.Grid.MultipleMaxtrix[i];
            }
            //Reverse list to desired order before returning.
            reverseCoordinates.Reverse();
            return reverseCoordinates;
        }
    }
}
