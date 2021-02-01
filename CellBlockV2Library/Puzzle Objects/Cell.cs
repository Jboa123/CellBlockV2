using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

/// <summary>
/// A fundamental object in the puzzle.
/// The Grid is made up of a collection of Cells.
/// </summary>
namespace CellBlockV2Library.Puzzle_Objects
{
    class cell : ICell
    {
        public cell(List<int> coordinates)
        {
            Coordinates = coordinates;
            Instances.Push(new CellInstance());
        }
        /// <summary>
        /// Returns the PossibleOwners from the top of the instances stack.
        /// </summary>
        public Dictionary<IMainBlock, LinkedList<int>> GetPossibleOwners { get => Instances.Peek().PossibleOwners;}
        /// <summary>
        /// Returns the PossibleMainBlocks from the top of the instances stack.
        /// </summary>
        public LinkedList<IMainBlock> GetPossibleMainBlocks { get => Instances.Peek().PossibleMainBlocks;}
        /// <summary>
        /// Returns the owning MainBlock from the top of the instances stack.
        /// Returns null if the owner is unknown.
        /// </summary>
        public IMainBlock Owner 
            { 
                get => Instances.Peek().OwnedBy;
                //If the Owner is known the possibleOwners properties are no longer required.
                set
                { 
                Instances.Peek().OwnedBy = value;
                Instances.Peek().PossibleMainBlocks = null;
                Instances.Peek().PossibleOwners = null;
                }
            }
        /// <summary>
        /// The Cartesian coordinates of the cell;
        /// </summary>
        public List<int> Coordinates { get; set ; }
        /// <summary>
        /// An instances contains the cells posssible owners.
        /// An instance can be duplicated when trial and error is required. Preservering the original data.
        /// </summary>
        public Stack<ICellInstance> Instances { get; set; } = new Stack<ICellInstance>();

    }
}
