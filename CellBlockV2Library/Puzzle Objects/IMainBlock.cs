using System.Collections.Generic;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// A fundamental object in the puzzle.
    /// The Cells that make up te MainBlock define the solution to the puzzle.
    /// </summary>
    public interface IMainBlock
    {
        /// <summary>
        /// The number of Cells contained within this MainBlock
        /// </summary>
        int Capacity { get; set; }
        /// <summary>
        /// The Cell that was initally provided.
        /// </summary>
        int Index { get; set; }
        /// <summary>
        /// The position of his MainBlock in the Grid.MainBlocks list.
        /// </summary>
        Stack<IMainBlockInstance> Instances { get; set; }
        /// <summary>
        /// As trial and error may be required. Each instance stores data that can be copied and modified whilst retaining the original data.
        /// </summary>
        ICell PreDefinedCell { get; set; }
    }
}