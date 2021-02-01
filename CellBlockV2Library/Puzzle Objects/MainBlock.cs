using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// A fundamental object in the puzzle.
    /// The Cells that make up te MainBlock define the solution to the puzzle.
    /// </summary>
    public class MainBlock : IMainBlock
    {
        /// <summary>
        /// Also creates the first MainBlockInstance and adds it to the stack.
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="preDefinedCell"></param>
        /// <param name="index"></param>
        public MainBlock(int capacity, ICell preDefinedCell, int index)
        {
            PreDefinedCell = preDefinedCell;
            Capacity = capacity;
            Index = index;
            Instances.Push(new MainBlockInstance());
        }
        /// <summary>
        /// Returns the PossibleBlocks hashset from the top of the Instances stack.
        /// </summary>
        public HashSet<int> PossibleBlocks { get => Instances.Peek().PossibleBlocks; set => Instances.Peek().PossibleBlocks = value; }
        /// <summary>
        /// The index of the PossibleBlock that represents the solution to this MainBlock.
        /// Set as -1 if unknown.
        /// </summary>
        public int Solution
        {
            get => Instances.Peek().SolutionIndex;
            //PossibleBlocks no longer required when a solution is found.
            set
            {
                Instances.Peek().SolutionIndex = value;
                Instances.Peek().PossibleBlocks = null;
            }
        }
        /// <summary>
        /// The number of Cells contained within this MainBlock
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// The Cell that was initally provided.
        /// </summary>
        public ICell PreDefinedCell { get; set; }
        /// <summary>
        /// The position of his MainBlock in the Grid.MainBlocks list.
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// As trial and error may be required. Each instance stores data that can be copied and modified whilst retaining the original data.
        /// </summary>
        public Stack<IMainBlockInstance> Instances { get; set; } = new Stack<IMainBlockInstance>();
    }
}
