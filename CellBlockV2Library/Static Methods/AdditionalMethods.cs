using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Static_Methods
{
    /// <summary>
    /// Static methods used by various classes.
    /// </summary>
    public static class AdditionalMethods
    {
        /// <summary>
        /// Returns the Multiple Matrix of the input dimension set.
        /// </summary>
        /// <param name="dimensionSet"></param>
        /// <returns></returns>
        public static List<int> GetMultipleMatrix(List<int> dimensionSet)
        {   
            //By definition, the first value is always 1 in the multiple matrix.
            List<int> multipleMatrix = new List<int>();
            multipleMatrix.Add(1);
            for (int i = 0; i < dimensionSet.Count; i++)
            {
                multipleMatrix.Add(multipleMatrix[i] * dimensionSet[i]);
            }
            return multipleMatrix;
        }
        /// <summary>
        /// Sets the DimensionSet, DimensionSetm MultipleMatrix properties and Index.
        /// </summary>
        public static IPossibleBlock CreatePossibleBlockFromIndex(IMainBlock mainBlock, Dictionary<int,List<List<int>>> blockDimensionSets, int index )
        {
            IPossibleBlock possibleBlock = new PossibleBlock(mainBlock);
            possibleBlock.Index = index;
            possibleBlock.DimensionSetIndex = index / mainBlock.Capacity;
            possibleBlock.DimensionSet = blockDimensionSets[mainBlock.Capacity][possibleBlock.DimensionSetIndex];
            possibleBlock.MultipleMatrix = AdditionalMethods.GetMultipleMatrix(possibleBlock.DimensionSet);
            return possibleBlock;
        }
        /// <summary>
        /// Sets the DimensionSet, DimensionSet and MultipleMatrix properties.
        /// </summary>
        public static IPossibleBlock CreatPossibleBlockFromDimensionSetIndex(IMainBlock mainBlock, Dictionary<int, List<List<int>>> blockDimensionSets, int dimensionSetIndex)
        {
            IPossibleBlock possibleBlock = new PossibleBlock(mainBlock);
            possibleBlock.DimensionSetIndex = dimensionSetIndex;
            possibleBlock.DimensionSet = blockDimensionSets[mainBlock.Capacity][dimensionSetIndex];
            possibleBlock.MultipleMatrix = AdditionalMethods.GetMultipleMatrix(possibleBlock.DimensionSet);
            return possibleBlock;
        }
        /// <summary>
        /// The input is the global list of MainBlocks, Grid.MainBlocks.
        /// </summary>
        /// <param name="mainBlocks"></param>
        /// <returns></returns>
        public static IMainBlock GetMainBlockWithFewestPossibleBlock(List<IMainBlock> mainBlocks)
        {
            //Keeps Tract of the MainBlock with the fewest remaining PossibleBlock.
            //It is returned and will be used to set each of its PossibleBlocks.
            IMainBlock MBWithFewestPB = null;
            foreach (IMainBlock mainBlock in mainBlocks)
            {
                if (mainBlock.Solution == -1)
                {
                    if (MBWithFewestPB == null)
                    {
                        MBWithFewestPB = mainBlock;
                    }
                    else if (mainBlock.PossibleBlocks.Count < MBWithFewestPB.PossibleBlocks.Count)
                    {
                        MBWithFewestPB = mainBlock;
                    }
                }
            }
            return MBWithFewestPB;
        }
    }
}
