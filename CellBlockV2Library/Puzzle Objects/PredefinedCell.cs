using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public class PredefinedCell : IPredefinedCell
    {
        public int Value { get; set; }

        public List<int> Coordinates { get; set; }

    }
}
