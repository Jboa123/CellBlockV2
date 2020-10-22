using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    class UserInputValidator
    {
        public List<List<string>> PredefinedCells { get; set; }
        public List<string> PuzzleDimensions { get; set; }
        private IPuzzleData _puzzleData;

        public bool AllCellsContainIntegers()
        {
            foreach (var preDefinedCellString in PredefinedCells)
            {
                List<int> preDefinedCellInt = new List<int>();
                foreach (var value in preDefinedCellString)
                {
                    int number;
                    if(Int32.TryParse(value, out number))
                    {
                        preDefinedCellInt.Add(number);
                    }
                    else
                    {
                        return false;
                    }
                }
                _puzzleData.PreDefinedCells.Add(preDefinedCellInt);
            }
            return true;
        }

        public bool AllDimensionsAreIntegers()
        {
            foreach (var dimension in PuzzleDimensions)
            {
                int number;
                if(Int32.TryParse(dimension, out number))
                {
                    _puzzleData.PuzzleDimensions.Add(number);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
