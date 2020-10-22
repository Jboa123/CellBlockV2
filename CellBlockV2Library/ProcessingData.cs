using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CellBlockV2Library
{
    public class ProcessingData : IProcessingData
    {
        public Dictionary<int, List<List<int>>> BlockDimensionSets { get; set; }

        public IGrid Grid { get; set; }

        public int SolvedMainBlockCount { get; set; }

        public int MaxStackHeight { get; set; }

    }
}
