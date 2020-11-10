using System.Collections.Generic;

namespace CellBlockV2Library
{
    /// <summary>
    /// Stores the solution to a puzzle
    /// </summary>
    public interface ISolutionData
    {
        /// <summary>
        /// The inner list stores 1 solution. Each integer represents the possible block index of the solution to a MainBlock.
        /// The list is ordered with respect to the MainBlocks List.
        /// The outer list hold all possible solutions to the puzzle.
        /// </summary>
        List<List<int>> Solutions { get; set; }
    }
}