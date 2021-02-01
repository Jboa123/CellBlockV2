using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library
{
    public interface IGetCellsFromIndex
    {
        List<ICell> GetCells(IPossibleBlock possibleBlock);
    }
}