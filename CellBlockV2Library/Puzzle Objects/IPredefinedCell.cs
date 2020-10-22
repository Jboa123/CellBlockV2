using System.Collections.Generic;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IPredefinedCell
    {
        List<int> Coordinates { get; set; }
        int Value { get; set; }
    }
}