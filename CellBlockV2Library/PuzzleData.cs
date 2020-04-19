using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{


    public class PuzzleData : IPuzzleData
    {
        List<int> PuzzleDimensions { get; set; }

        public List<List<int>> PreDefinedCells { get; set; }
        public int NumberOfDimensions { get; set; }
        public int TotalCells { get; set; }

        public PuzzleData()
        {
            GetTotalCells();
        }
        /// <summary>
        /// Calculate total number of Cells. All values are kept as integers
        /// </summary>
        private void GetTotalCells()
        {
            TotalCells = 1;
            for (int i = 0; i < NumberOfDimensions; i++)
            {
                TotalCells *= SideLength;
            }
        }
    }
}
