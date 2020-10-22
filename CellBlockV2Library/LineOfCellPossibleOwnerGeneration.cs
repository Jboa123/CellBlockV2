using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    public class LineOfCellPossibleOwnerGeneration : CoreProperties
    {
        public Stack<ICell> NextDimensionCells { get; set; }
        public int CurrentDimensionIndex { get; set; }
        public List<int> PossibleBlockDimensions { get; set; }
        public List<int> PossibleBlockMultipleMatrix { get; set; }
        public ICell CentralCell { get; set; }
        public int MinPossibleBlockIndex { get; set; }
        public int MaxPossibleBlockIndex { get; set; }
        private int CurrentDimensionLength{ get; set; }
        private List<int> CentralCellCoordinates{ get; set; }
        private Dictionary<IMainBlock, IPossibleBlock> CentralCellPossibleOwners { get; set; }
        private List<int> Nodes { get; set; }
        public IMainBlock MainBlock { get; set; }
        private int NodesSeparation { get; set; }
        private int NumbPossibleOwnersToAdd { get; set; }

        public void FillLine()
        {
            ICell outerCell;
            for (int i = -CurrentDimensionLength +1; i <= CurrentDimensionLength -1; i++)
            {
                List<int> outerCellCartesianCoordinates = new

                outerCell = Grid.GetCellFromCartesian()



            }
        }

        private ICell getOuterCell(int offset)
        {
            ICell cell;
            List<int> cellCoordinates = new List<int>();
            foreach (int pos in PossibleBlockDimensions)
            {

            }
        }
        /// <summary>
        /// Adds all PossibleBlocks, corresponding to the specified MainBlock, that contain the input Cell to the Cells PossibleOwners Dictionary.
        /// Adds the Cell to the PossibleBlocks collection of Cells.
        /// </summary>
        /// <param name="outerCell"></param>
        private void GetCellPossibleBlocks(ICell outerCell)
        {
            int cellOffset = outerCell.Coordinates[CurrentDimensionIndex] - CentralCell.Coordinates[CurrentDimensionIndex];
            Dictionary<int,IPossibleBlock> outerCellPossibleOwners = new Dictionary<int, IPossibleBlock>();
            Dictionary<int,IPossibleBlock> centralCellPossibleOwners = CentralCell.PossibleOwners[MainBlock];


            for (int i = 0; i <Nodes.Count;i++)
            {
                if(cellOffset >0 && i != 0)
                {
                    for (int j = 1; j <= NumbPossibleOwnersToAdd; j++)
                    {
                        centralCellPossibleOwners[Nodes[i] - j].Cells.Add(outerCell);
                        outerCellPossibleOwners.Add(Nodes[i] - j, centralCellPossibleOwners[Nodes[i] - j]);
                    }
                }
                else if(cellOffset <0 && i != Nodes.Count-1)
                {
                    for (int j = 0; j < NumbPossibleOwnersToAdd; j++)
                    {
                        centralCellPossibleOwners[Nodes[i] - j].Cells.Add(outerCell);
                        outerCellPossibleOwners.Add(Nodes[i] + j, centralCellPossibleOwners[Nodes[i] + j]);
                    }
                }
            }
            outerCell.PossibleOwners.Add(MainBlock, outerCellPossibleOwners);
        }


        private void GetNodes()
        {
            int counter = MinPossibleBlockIndex;
            List<int> nodes = new List<int>();
            while (counter <= MaxPossibleBlockIndex)
            {
                nodes.Add(counter);
                counter += PossibleBlockMultipleMatrix[CurrentDimensionIndex + 1];
            }
            Nodes = nodes;
        }
    }
}
