using System.Collections.Generic;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IMainBlockInstance
    {
        HashSet<int> PossibleBlocks { get; set; }
        int SolutionIndex { get; set; }
    }
}