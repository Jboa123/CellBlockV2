using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// A fundamental puzzle object. Holds referecnes to all Cells and MainBlocks.
    /// Also stores the mutiple matrix which is used to convert between linear and multi-dimensional coordinates.
    /// </summary>
    public class Grid : IGrid
    {
        /// <summary>
        /// A value in the mulitple matrix, of index n, represents the number of Cells in a layer with dimensions n-1.
        /// ie a 3x2 grid has MM of [1,3,6], a 1 dimensional layer has 3 cells and a 2 dimensional layer has 6 cells.
        /// Used to convert between multi-dimensional coordinate and linear indexing.
        /// </summary>
        public List<int> MultipleMaxtrix { get; set; }
        /// <summary>
        /// All the Cells within the Grid.
        /// </summary>
        public List<ICell> Cells { get; set; } = new List<ICell>();
        /// <summary>
        /// All the MainBlock within the Grid.
        /// </summary>
        public List<IMainBlock> MainBlocks { get; set; } = new List<IMainBlock>();
        /// <summary>
        /// An integer representing the maximum number of Cell or MainBlock instaces that currently exist.
        /// </summary>
        public int SolvedMainBlockCount { get; set; } = 0;
        /// <summary>
        /// The number of solved MainBlocks based on the top of the MainBlock instances stack.
        /// Used to check if a solution has been found.
        /// </summary>
        public int MaxStackHeight { get; set; } = 1;
        public bool HasSolution
        {
            get
            {
                if (SolvedMainBlockCount == MainBlocks.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns the cell with the given Cooordinates
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public ICell GetCellFromCoordinates(List<int> coordinates)
        {
            return Cells[GetListPositionFromCoordinates(coordinates)];
        }
        /// <summary>
        /// Returns a Cell in which only 1 coordinate differs from that of the input cell.
        /// The first int is the index of the coordinate that differs, the second is absolute difference between the 2 values (returned cell coorindate - input cell coordinate).
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="dimensionIndex"></param>
        /// <param name="offet"></param>
        /// <returns></returns>
        public ICell GetCellFromOffset(ICell cell, int dimensionIndex, int offet)
        {
            return Cells[GetListPositionFromCoordinates(cell.Coordinates) + MultipleMaxtrix[dimensionIndex] * offet];
        }

        /// <summary>
        /// Returns the index of the cell, with the input coordinates, in the Cells list.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private int GetListPositionFromCoordinates(List<int> coordinates)
        {
            int listPosition = 0;
            for (int i = 0; i < coordinates.Count; i++)
            {
                listPosition += MultipleMaxtrix[i] * coordinates[i];
            }
            return listPosition;
        }
    }
}
