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
    class Grid : IGrid
    {

        public List<int> MultipleMaxtrix { get; set; }
        public List<ICell> Cells { get; set; } = new List<ICell>();
        public List<IMainBlock> MainBlocks { get; set; } = new List<IMainBlock>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public ICell GetCellFromCoordinates(List<int> coordinates)
        {
            return Cells[GetListPositionFromCoordinates(coordinates)];
        }
        /// <summary>
        /// 
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
        /// A value in the mulitple matrix, of index n, represents the number of Cells in a layer with dimensions n-1.
        /// ie a 3x2 grid has MM of [1,3,6], a 1 dimensional layer has 3 cells and a 2 dimensional layer has 6 cells.
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
