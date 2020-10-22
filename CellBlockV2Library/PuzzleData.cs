using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{


    public class PuzzleData : IPuzzleData
    {
        public PuzzleData()
        {
            GetTotalCapacity();
        }

        public List<int> PuzzleDimensions { get; set; }

        public List<List<int>> PreDefinedCells { get; set; }
        public int TotalCapacity{ get; set; }


        /// <summary>
        /// Calculate total number of Cells. All values are kept as integers
        /// </summary>
        private void GetTotalCapacity()
        {
          this.TotalCapacity = 1;
          foreach(int dimension in this.PuzzleDimensions)
          {
                this.TotalCapacity *= dimension;
          }
        }
    }
}
