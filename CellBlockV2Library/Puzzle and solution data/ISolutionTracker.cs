using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library
{
    /// <summary>
    /// Stores the data used when finding the solution to the puzzle
    /// </summary>
    public interface ISolutionTracker
    {
        /// <summary>
        /// The key represents the capacity of a block.
        /// The value holds all possible combinations of side lengths a block of the given capacity could be.
        /// The inner list holds 1 set of possible side lengths.
        /// </summary>
        Dictionary<int, List<List<int>>> BlockDimensionSets { get; set; }
        /// <summary>
        /// The Grid holds references to all Cells and MainBlocks.
        /// </summary>
        IGrid Grid { get; set; }

        /// <summary>
        /// Stores the solutions to the puzzle, once found.
        /// The inner list holds a single solution.
        /// Each int represents the index of a possible block that in turn reprents the solution to a MainBlock.
        /// The order of the list is aligned with the Grid.MainBlocks list.
        /// The outer list stores all solutions.
        /// </summary>
        List<List<int>> Solutions { get; set; }
    }
}