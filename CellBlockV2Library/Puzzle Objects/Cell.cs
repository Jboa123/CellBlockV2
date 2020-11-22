using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// A fundamental object in the puzzle.
/// The Grid is made up of a collection of Cells.
/// </summary>
namespace CellBlockV2Library.Puzzle_Objects
{
    class Cell : ICell
    {
        public Cell(List<int> coordinates)
        {
            Coordinates = coordinates;
            Instances.Push(new CellInstance());
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
