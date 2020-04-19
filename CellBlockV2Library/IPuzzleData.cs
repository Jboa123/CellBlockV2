using System.Collections.Generic;

namespace CellBlockV2Library
{
    /// <summary>
    /// Holds the information for a specific puzzle. Data will be passed down from the GUI
    /// </summary>
    public interface IPuzzleData
    {
        int NumberOfDimensions { get; set; }
        /// <summary>
        /// The inner list will hold data about a single predefined Cell with the value (Block area) at index 0 in the list. The cartesian coordinates follow starting at index 1.
        /// The outer list holds all the predefined Cells.
        /// </summary>
        List<List<int>> PreDefinedCells { get; set; }
        /// <summary>
        /// The length of each dimension in Cells for this puzzle.
        /// </summary>
        List<int> PuzzleDimensions { get; set; }
        /// <summary>
        /// A integer represesnting the total number of Cells that make up the Puzzle. The product of all PuzzleDimensions.
        /// </summary>
        int TotalCapacity { get; set; }
    }
}