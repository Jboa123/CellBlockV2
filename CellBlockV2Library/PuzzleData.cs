using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{

    /// <summary>
    /// Holds the information for a specific puzzle. Data will be passed down from the GUI
    /// </summary>
    public class PuzzleData
    {
        public int SideLength { get; set; }
        /// <summary>
        /// The inner list will hold data about a single predefined Cell with the value (Block area) at index 0 in the list. The cartesian coordinates follow starting at index 1.
        /// The outer list holds all the predefined Cells.
        /// </summary>
        public List<List<int>> PreDefinedCells { get; set; }
        public int NumberOfDimensions { get; set; }
        public int TotalCells { get ; set; }

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
