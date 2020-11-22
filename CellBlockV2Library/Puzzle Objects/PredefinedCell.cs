using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// Part of the data that defines the puzzle.
    /// </summary>
    public class PredefinedCell : IPredefinedCell
    {
        /// <summary>
        /// The capacity of the MainBlock that owns this Cell.
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Cartesian coordinates.
        /// </summary>
        public List<int> Coordinates { get; set; }

    }
}
