using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// A fundamental object in the puzzle.
    /// The Grid is made up of a collection of Cells.
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Returns the PossibleOwners from the top of the instances stack.
        /// </summary>
        Dictionary<IMainBlock, LinkedList<int>> GetPossibleOwners { get; }
        /// <summary>
        /// Returns the PossibleMainBlocks from the top of the instances stack.
        /// </summary>
        LinkedList<IMainBlock> GetPossibleMainBlocks { get; }
        /// <summary>
        /// Returns the owning MainBlock from the top of the instances stack.
        /// Returns null if the owner is unknown.
        /// </summary>
        public IMainBlock Owner { get; set; }
        /// <summary>
        /// The Cartesian coordinates of the cell;
        /// </summary>
        List<int> Coordinates { get; set; }

        /// <summary>
        /// An instances contains the cells posssible owners.
        /// An instance can be duplicated when trial and error is required. Preservering the original data.
        /// </summary>
        Stack<ICellInstance> Instances { get; set; }
    }
}
