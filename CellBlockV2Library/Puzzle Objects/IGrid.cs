using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IGrid
    {
        /// <summary>
        /// A list containing all the Cells that make up this Grid.
        /// </summary>
        List<ICell> Cells { get; set; }
        /// <summary>
        /// A list of all the MainBlocks. A MainBlock and this.MainBlocks[MainBlock.index] are the same object.
        /// </summary>
        List<IMainBlock> MainBlocks { get; set; }
        /// <summary>
        /// The number of Cells within this Grid that are marked as owned.
        /// </summary>
        int SolvedCellCount { get; set; }
        /// <summary>
        /// If the Grid's capacity is equal to SolvedCellCount, the Grid has a solution. True is returned if the Grid has a solution, otherwise false.
        /// </summary>
        bool HasSolution { get;}
}
}
