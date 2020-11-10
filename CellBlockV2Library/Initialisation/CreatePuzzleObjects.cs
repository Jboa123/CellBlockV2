using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Initialisation
{
    public class CreatePuzzleObjects
    {
        private IProcessingData _processingData { get; set; }
        private IPuzzleData _puzzleData { get; set; }

        public void CreateAllPuzzleObjects()
        {

        }
        private void CreateCells()
        {
            for (int i = 0; i < Calculations.GetCapacity(_puzzleData.SideLengths); i++)
            {
                ICell cell = new Cell();
                cell.Instances.Add(new CellInstance());
                _processingData.Grid.Cells.Add(cell);
                cell.Coordinates = GetCoordinatesFromLinearPosition(i);
            }
        }

        private void CreateMainBlocks()
        {
            for(int i = 0; i< _puzzleData.PreDefinedCells.Count;i++)
            {
                IMainBlock mainBlock = new MainBlock(PDC);
                mainBlock.PreDefinedCell = Calculations.GetCellFromCoordinates(PDC.Coordinates);
                mainBlock.PreDefinedCell.instances.peek.OwnedBy = mainBlock;
                mainBlock.Index = i;
                mainBlock.Instances.Add(new MainBlockInstance());
                _processingData.Grid.MainBlocks.Add(mainBlock);
            }
        }

        private List<int> GetCoordinatesFromLinearPosition(int linearPosition)
        {
            List<int> multipleMatrix = Calculations.GetMultipleMatrix(_puzzleData.SideLengths);
            List<int> reverseCoordinates = new List<int>();
            for (int i = _puzzleData.SideLengths.Count-1; i >= 0; i--)
            {
                reverseCoordinates.Add(linearPosition / multipleMatrix[i]);
                linearPosition = linearPosition % multipleMatrix[i];
            }
            reverseCoordinates.Reverse();
            return reverseCoordinates;
        }

    }
}
