using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    /// <summary>
    /// Stores the solution to a puzzle
    /// </summary>
    public class SolutionData : ISolutionData
    {
        public List<List<int>> Solutions { get; set; }
    }
}
