using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public class MainBlockInstance : IMainBlockInstance
    {
        public HashSet<int> PossibleBlocks { get; set; }

        public int SolutionIndex { get; set; }
    }
}
