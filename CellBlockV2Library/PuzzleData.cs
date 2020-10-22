using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    public class PuzzleData : IPuzzleData
    {
        public PuzzleData()
        {

        }
        public List<int> SideLengths { get; set; }
        public List<IPredefinedCell> PreDefinedCells { get; set; }
        public int TotalCapacity
        {
            //Multiply each side length to calculate total capacity.
            get
            {
                int capacity = 1;
                foreach (int length in SideLengths)
                {
                    capacity *= length;
                }
                return capacity;
            }
        }

    }
}
