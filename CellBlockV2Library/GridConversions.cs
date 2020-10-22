using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    public class GridConversions : IGridConversions
    {
        private IPuzzleData _puzzleData;

        public GridConversions(IPuzzleData puzzleData)
        {
            _puzzleData = puzzleData;
            CreateMultipleMaxtrix();
        }
        private List<int> GridMultipleMatrix { get; set; }
        public int CartesianToListPosition(List<int> cartesianCoordinates)
        {
            int listPosition = 0;
            for (int i = 0; i < cartesianCoordinates.Count; i++)
            {
                listPosition += cartesianCoordinates[i] * GridMultipleMatrix[i];
            }
            return listPosition;
        }

        private void CreateMultipleMaxtrix()
        {
            int multiple = 1;
            GridMultipleMatrix.Add(multiple);
            foreach (int dimension in _puzzleData.PuzzleDimensions)
            {
                multiple *= dimension;
                GridMultipleMatrix.Add(multiple);
            }
        }
    }
}
