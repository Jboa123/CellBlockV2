using System.Collections.Generic;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IPossibleBlock
    {
        /// <summary>
        /// All the Cells contained within this PossibleBlock.
        /// </summary>
        List<ICell> Cells { get; set; }
        /// <summary>
        /// The set of block dimensions currently being processed.
        /// </summary>
        List<int> DimensionSet { get; set; }
        /// <summary>
        /// The index of the current dimension set in block dimension sets list in solution tracker.
        /// Directly used in the calculation of a possible block index.
        /// </summary>
        int DimensionSetIndex { get; set; }
        /// <summary>
        /// The PossibleBlock Index
        /// </summary>
        int Index { get; set; }
        /// <summary>
        /// The MainBlock that this PossibleBlock belongs to.
        /// </summary>
        IMainBlock MainBlock { get; set; }
        /// <summary>
        /// Multiple matrix of the current block dimensions set.
        /// </summary>
        List<int> MultipleMatrix { get; set; }

    }
}        