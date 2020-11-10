using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library
{
    /// <summary>
    /// Stores the data used when finding the solution to the puzzle
    /// </summary>
    public interface IProcessingData
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
        /// An integer representing the maximum number of Cell or MainBlock instaces that currently exist.
        /// </summary>
        int MaxStackHeight { get; set; }
        /// <summary>
        /// An integer representing the number of solved MainBlocks based on the top of the MainBlock instances stack.
        /// Used to check if a solution has been found.
        /// </summary>
        int SolvedMainBlockCount { get; set; }
    }
}