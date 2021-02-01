using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// A fundamental puzzle object. Holds referecnes to all Cells and MainBlocks.
    /// Also stores the mutiple matrix which is used to convert between linear and multi-dimensional coordinates.
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// A value in the mulitple matrix, of index n, represents the number of Cells in a layer with dimensions n-1.
        /// ie a 3x2 grid has MM of [1,3,6], a 1 dimensional layer has 3 cells and a 2 dimensional layer has 6 cells.
        /// </summary>
        List<int> MultipleMaxtrix { get; set; }
        /// <summary>
        /// All the Cells within the Grid.
        /// </summary>
        List<ICell> Cells { get; set; }
        /// <summary>
        /// All the MainBlock within the Grid.
        /// </summary>
        List<IMainBlock> MainBlocks { get; set; }
        /// <summary>
        /// An integer representing the maximum number of Cell or MainBlock instaces that currently exist.
        /// </summary>
        int MaxStackHeight { get; set; }
        /// <summary>
        /// The number of solved MainBlocks based on the top of the MainBlock instances stack.
        /// Used to check if a solution has been found.
        /// </summary>
        int SolvedMainBlockCount { get; set; }
        /// <summary>
        /// Returns true if the items on top of all the instances stacks represent a solution.
        /// </summary>
        bool HasSolution { get; }

        /// <summary>
        /// Returns the Cell with the given Cooordinates
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        ICell GetCellFromCoordinates(List<int> coordinates);

        /// <summary>
        /// Returns a Cell in which only 1 coordinate differs from that of the input cell.
        /// The first int is the index of the coordinate that differs, the second is absolute difference between the 2 values (returned cell coorindate - input cell coordinate).
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="dimensionIndex"></param>
        /// <param name="offet"></param>
        /// <returns></returns>
        ICell GetCellFromOffset(ICell cell, int dimensionIndex, int offet);
        
    }
}
