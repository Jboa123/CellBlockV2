using System.Collections.Generic;

namespace CellBlockV2Library.Puzzle_Objects
{    /// <summary>
     /// Part of the data that defines the puzzle.
     /// </summary>
    public interface IPredefinedCell
    {   /// <summary>
        /// The capacity of the MainBlock that owns this Cell.
        /// </summary>
        List<int> Coordinates { get; set; }
        /// <summary>
        /// Cartesian coordinates.
        /// </summary>
        int Value { get; set; }
    }
}