using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CellBlockV2Library
{
    /// <summary>
    /// Stores the data used when finding the solution to the puzzle
    /// </summary>
    public class SolutionTracker : ISolutionTracker
    {
        /// <summary>
        /// The key represents the capacity of a block.
        /// The value holds all possible combinations of side lengths a block of the given capacity could be.
        /// The inner list holds 1 set of possible side lengths.
        /// </summary>
        public Dictionary<int, List<List<int>>> BlockDimensionSets { get; set; } = new Dictionary<int, List<List<int>>>();
        /// <summary>
        /// The Grid holds references to all Cells and MainBlocks.
        /// </summary>
        public IGrid Grid { get; set; } = new Grid();

        /// <summary>
        /// Stores the solutions to the puzzle, once found.
        /// The inner list holds a single solution.
        /// Each int represents the index of a possible block that in turn reprents the solution to a MainBlock.
        /// The order of the list is aligned with the Grid.MainBlocks list.
        /// The outer list stores all solutions.
        /// </summary>
        public List<List<int>> Solutions { get; set; } = new List<List<int>>();


    }
}
