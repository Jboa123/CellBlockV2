using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    public abstract class CoreProperties : ICoreProperties
    {
        public IGrid Grid { get; set; }
    }
}
