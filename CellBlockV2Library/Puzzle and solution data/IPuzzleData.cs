using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library
{
    /// <summary>
    /// Hold the data that defines the puzzle.
    /// </summary>
    public interface IPuzzleData
    {
        /// <summary>
        /// The side lengths of the Grid.
        /// Provided by the user.
        /// </summary>
        List<int> SideLengths { get; set; }
        /// <summary>
        /// All the PredfinedCells(PDC) that define this puzzle. Each PDC holds a value(capacity) and Coordinates.
        /// Provided by the user.
        /// </summary>
        List<IPredefinedCell> PreDefinedCells { get; set; }
    }
}