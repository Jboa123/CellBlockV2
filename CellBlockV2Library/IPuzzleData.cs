using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library
{
    /// <summary>
    /// Hold the data that defines the puzzle as well as the solutions.
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
        /// <summary>
        /// Stores the solutions to the puzzle, once found.
        /// The inner list holds a single solution.
        /// Each int represents the index of a possible block that in turn reprents the solution to a MainBlock.
        /// The order of the list is aligned with the Grid.MainBlocks list.
        /// The outer list stores all solutions.
        /// </summary>
        List<List<int>> Solutions { get; set; }
        /// <summary>
        /// The total number of cells contained within the Grid.
        /// </summary>
        int TotalCapacity { get;}
    }
}