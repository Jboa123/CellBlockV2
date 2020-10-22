using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library
{
    /// <summary>
    /// Holds the information that defines a puzzle. Data will be passed down from the GUI.
    /// </summary>
    public interface IPuzzleData
    {
        /// <summary>
        /// All the PredfinedCells(PDC) that define this puzzle. Each PDC holds a value(capacity) and Coordinates.
        /// </summary>
        List<IPredefinedCell> PreDefinedCells { get; set; }
        /// <summary>
        /// The length of each dimension for this puzzle.
        /// </summary>
        List<int> SideLengths { get; set; }
        /// <summary>
        /// A integer represesnting the total number of Cells that make up the Puzzle.
        /// </summary>
        int TotalCapacity { get;}
    }
}