using CellBlockV2Library.PossibleBlockInitialisation;
using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    public class PossibleBlockInitialisation1 : PossibleBlockInitialisationCore
    {
        private IPuzzleData _puzzleData;
        /// <summary>
        /// Will initially hold all PossibleBlocks for the given dimensions and PreDefinedCell. Those that are not within the Grid or that contain a different PreDefinedCell will be removed.
        /// </summary>
        public Dictionary<int, IPossibleBlock> AllPossibleBlocks { get; set; }
        ICollection<int> InValidPossibleBlocks { get; set; }
        public IMainBlock MainBlock { get; set; }
        public ICell PreDefinedCell { get; set; }
        public List<int> BlockDimensions { get; set; }
        public List<int> BlockMultipleMatrix { get; set; }
        private IPossibleBlock PossibleBlockPrototype { get; set; }
        public Stack<ICell> CentralCells { get; set; }
        public Queue<Stack<ICell>>  UnProcessedCells { get; set; }


        public PossibleBlockInitialisation1()
        {

        }
        private void GenerateCellPossibleOwners(ICell centralCell, int minIndex, int maxIndex)
        {
            for (int i = minIndex; i <= maxIndex; i++)
            {

            }
        }



        /// <summary>
        /// For the given BlockDimensions and PreDefinedCell which must be contained within the Block, finds the reach, in each dimension, that extends beyond the Grid.
        /// </summary>
        private void LiesWithinGrid()
        {
            List<Tuple<int, int>> outOfbounds = new List<Tuple<int, int>>();
            List<int> coordinates = PreDefinedCell.Coordinates;
            List<int> puzzleDimensions = _puzzleData.PuzzleDimensions;
            for (int i = 0; i < puzzleDimensions.Count; i++)
            {
                outOfbounds.Add(GetRangeOutOfBounds(coordinates[i], puzzleDimensions[i]));
            }
        }
        /// <summary>
        /// Returns a Tuple<int,int> where the first int is range that the PossibleBlocks extend beyond the origin of the Grid in the given axis.
        /// The second int range that the PossibleBlocks extend beyond the maximum of the Grid in the given axis.
        /// dimensionIndex would traditionally represent a value x,y,z... etc. This value is 0 based.
        /// PositionInGivenDimension represents the Predefined Cell's value in the given dimension.
        /// For example the cartesian coordinates: x,y,z is equivalent to dimensionIndexes: 0,1,2 respectively.
        /// The value x=5 wouold be equivalent to dimensionIndex = 0  and positionInGivenDimension = 5.
        /// This function would be called 3 times in the given example, to get complete set of data.
        /// </summary>
        /// <param name="positionInGivenDimension"></param>
        /// <param name="dimensionIndex"></param>
        /// <returns></returns>
        private Tuple<int,int> GetRangeOutOfBounds(int positionInGivenDimension, int dimensionIndex)
        {
            int rangeOutSideGridFromOrigin;
            int rangeOutSideGridFromMax;
            int blockDimension = BlockDimensions[dimensionIndex];
            int dimensionLength = _puzzleData.PuzzleDimensions[dimensionIndex];

            if (positionInGivenDimension - blockDimension < 0)
            {
                rangeOutSideGridFromOrigin = blockDimension - positionInGivenDimension - 1;
            }
            else
            {
                rangeOutSideGridFromOrigin = 0;
            }

            if (positionInGivenDimension + blockDimension >= dimensionLength)
            {
                rangeOutSideGridFromMax = positionInGivenDimension + blockDimension - dimensionLength;
            }
            else
            {
                rangeOutSideGridFromMax = 0;
            }

            return new Tuple<int, int>(rangeOutSideGridFromOrigin,rangeOutSideGridFromMax);
        }
    }
}
