using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library
{
    public interface IProcessingData
    {
        Dictionary<int, List<List<int>>> BlockDimensionSets { get; set; }
        IGrid Grid { get; set; }
        int MaxStackHeight { get; set; }
        int SolvedMainBLockCount { get; set; }
    }
}