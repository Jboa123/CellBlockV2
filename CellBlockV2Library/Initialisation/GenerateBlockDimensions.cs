using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace CellBlockV2Library.Initialisation
{
    public class GenerateBlockDimensions
    {
        private ISolutionTracker _solutionTracker;
        private IPuzzleData _puzzleData;
        public List<List<int>> AllDimensionSets { get; set; }


        /// <summary>
        /// Calculate all dimension sets for all block capacities in this puzzle.
        /// </summary>
        private void GetAllDimensionSets()
        {
            foreach(IPredefinedCell PDC in _puzzleData.PreDefinedCells)
            {
                if(_solutionTracker.BlockDimensionSets.ContainsKey(PDC.Value) == false)
                {
                    AllDimensionSets = new List<List<int>>();
                    GetSides(PDC.Value, PDC.Coordinates.Count - 1);
                    _solutionTracker.BlockDimensionSets.Add(PDC.Value, AllDimensionSets);
                }
            }
        }
        /// <summary>
        /// Calculates all possible dimension combinations for the given block capacity and puzzle dimension count.
        /// A recursive function, each call processing a single dimension.
        /// Returns an int representing the number of dimension sets afftected by the function call.
        /// This is so the calling function can append a the side length to the appropriate number of lists (dimension sets).
        /// </summary>
        /// <param name="remainingCapacity"></param>
        /// <param name="dimensionIndex"></param>
        /// <returns></returns>
        private int GetSides(int remainingCapacity, int dimensionIndex)
        {
            //Counts the total number of dimension sets affected by this call of the function.
            int totalListAffectedCount = 0;
            //The final dimension is reached, the list representing a dimension set is created. The only possible side length is added to the list.
            //The dimension set is added to the end of the AllDimensionSets list. More side lengths are appended to each dimensions set by the calling function.
            if (dimensionIndex == 0)
            {
                List<int> dimensionSet = new List<int>();
                dimensionSet.Add(remainingCapacity);
                AllDimensionSets.Add(dimensionSet);
                totalListAffectedCount++;
            }
            else 
            {   
                //Each factor of the remaining capacity represents a possible side length.
                foreach(int factor in GetUniqueFactors(remainingCapacity))
                {
                    //Each factor will have a number of possible combinations of proceeding side lengths.
                    int factorListAffectedCount = 0;
                    factorListAffectedCount = GetSides(remainingCapacity / factor, dimensionIndex--);
                    totalListAffectedCount += factorListAffectedCount;

                    //This side length (factor) is appended to the appropriate number of lists, starting from the end of the AllDimensionsSets list.
                    for (int i = AllDimensionSets.Count - 1; i < AllDimensionSets.Count-factorListAffectedCount; i--)
                    {
                        AllDimensionSets[i].Add(factor);
                    }

                }
            }
            //Return the number of lists (dimension sets) affected by this function allowing the caller to append side length to the correct number of lists.
            return totalListAffectedCount;
        }
        /// <summary>
        /// For the input int, a list of all its factors are returned.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private List<int> GetUniqueFactors(int number)
        {
            List<int> uniqueFactors = new List<int>();
            //Loop though all ints up to the squre root of the number.
            //If the number is divisible by i, then both i and number/i are factors.
            for (int i = 1; i <= number/i; i++)
            {   
                if (number%i == 0)
                {
                    uniqueFactors.Add(i);
                    //Check if i is the square root of the number, if it is don't add number/i to list as it is a duplicate factor.
                    if (i != number/i)
                    {
                    uniqueFactors.Add(number / i);
                    }
                }
            }
            return uniqueFactors;
        }
    }
}
