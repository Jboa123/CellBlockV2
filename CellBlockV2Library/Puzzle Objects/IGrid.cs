using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface IGrid
    {
        /// <summary>
        /// A list containing all the Cells that make up this Grid.
        /// </summary>
        List<ICell> Cells { get; set; }
        /// <summary>
        /// A list of all the MainBlocks. A MainBlock and this.MainBlocks[MainBlock.index] are the same object.
        /// </summary>
        List<IMainBlock> MainBlocks { get; set; }
        /// <summary>
        /// Returns the Cell that lies at the input coordinates.
        /// </summary>
        /// <param name="cartesianCoordinates"></param>
        /// <returns></returns>
        ICell GetCellFromCartesian(List<int> cartesianCoordinates);
    }
}
