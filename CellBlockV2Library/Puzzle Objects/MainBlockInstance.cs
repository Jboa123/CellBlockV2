﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// Stores data that may need to be copied and modified, retaining the original data.
    /// </summary>
    public class MainBlockInstance : IMainBlockInstance
    {
        /// <summary>
        /// Each int represents a possible block that is still a viable solution to the MainBlock
        /// </summary>
        public HashSet<int> PossibleBlocks { get; set; }
        /// <summary>
        /// When solved the value is set as the int corresponding to the possible block that represents the solution.
        /// a value of -1 represents no known solution.
        /// </summary>
        public int SolutionIndex { get; set; }
    }
}
