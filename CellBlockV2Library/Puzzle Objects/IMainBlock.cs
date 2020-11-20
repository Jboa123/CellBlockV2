using System.Collections.Generic;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IMainBlock
    {
        int Capacity { get; set; }
        int Index { get; set; }
        Stack<IMainBlockInstance> Instances { get; set; }
        ICell PreDefinedCell { get; set; }
    }
}