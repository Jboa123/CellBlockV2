using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public class MainBlock : IMainBlock
    {
        public int Capacity { get; set; }
        /// <summary>
        /// The Cell that was initally provided.
        /// </summary>
        public ICell PreDefinedCell { get; set; }
        /// <summary>
        /// The position of his MainBlock in the Grid.MainBlocks list.
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// As trial and error may be required. Each instance stores data that can be copied and modified whilst retaining the original data.
        /// </summary>
        public Stack<IMainBlockInstance> Instances { get; set; }
    }
}
