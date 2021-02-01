using CellBlockV2Library.Static_Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// Contains all the properties that a PossibleBlock contains.
    /// </summary>
    public class PossibleBlock : IPossibleBlock
    {
        ISolutionTracker SolutionTracker;

        /// <summary>
        /// The MainBlock that this PossibleBlock belongs to. The SolutionTracker contains all possible DimensionSets.
        /// </summary>
        /// <param name="mainBlock"></param>
        /// <param name="solutionTracker"></param>
        public PossibleBlock(IMainBlock mainBlock)
        {
            MainBlock = mainBlock;
        }
        
        /// <summary>
        /// The MainBlock that this PossibleBlock belongs to.
        /// </summary>
        public IMainBlock MainBlock { get; set; }
        /// <summary>
        /// Multiple matrix of the current block dimensions set.
        /// </summary>
        public List<int> MultipleMatrix { get; set; }
        /// <summary>
        /// The set of block dimensions currently being processed.
        /// </summary>
        public List<int> DimensionSet { get; set; }
        /// <summary>
        /// The index of the current dimension set in block dimension sets list in solution tracker.
        /// Directly used in the calculation of a possible block index.
        /// </summary>
        public int DimensionSetIndex { get; set; }
        /// <summary>
        /// The PossibleBlock in
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// All the Cells contained within this PossibleBlock.
        /// </summary>
        public List<ICell> Cells { get; set; }
    }
}
