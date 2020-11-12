using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace CellBlockV2Library.Puzzle_Objects
{
    class Cell : ICell
    {
        /// <summary>
        /// The Cartesian coordinates of the cell;
        /// </summary>
        public List<int> Coordinates { get; set ; }
        /// <summary>
        /// An instances contains the cells posssible owners.
        /// An instance can be duplicated when trial and error is required. Preservering the original data.
        /// </summary>
        public Stack<ICellInstance> Instances { get; set; }


    }
}
