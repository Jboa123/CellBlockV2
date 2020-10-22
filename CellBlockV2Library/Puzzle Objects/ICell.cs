using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface ICell
    {
        /// <summary>
        /// A dictionary with key as a MainBlock and the value as a list of all PossibleBlocks of equal index to the key, that contain this Cell.
        /// </summary>
        Dictionary<IMainBlock, Dictionary<int, IPossibleBlock>> PossibleOwners { get; set; }
     
        /// <summary>
        /// The Cartesian coordinates of the cell;
        /// </summary>
        List<int> Coordinates { get; set; }
        /// <summary>
        /// The MainBlock that owns this cell. If the Cell is not owned the value of this property is null.
        /// </summary>
        IMainBlock OwnedBy { get; set; }
        /// <summary>
        /// Is this Cell owned by a MainBlock other than that inputted? Returns true if so, otherwise false. 
        /// Accepts either a MainBlock or an integer representing the index of a MainBlock as a parameter.
        /// </summary>
        /// <param name="mainBlock"></param>
        /// <param name="mainBlockIndex"></param>
        /// <returns></returns>
        bool IsOwnedByBlockOtherThan(IMainBlock mainBlock);
        bool IsOwnedByBlockOtherThan(int mainBlockIndex);
        /// <summary>
        /// Marks this Cell as owned. Setting all relevant properties, as well as incrementing the SolvedCellCount property of the corresponding Grid.
        /// Accepts either a MainBlock or an integer representing the index of a MainBlock as a parameter.
        /// This is the only method that should modify the Cell.OwnedBy, Grid.SolvedCellCount or MainBlock.Cells. 
        /// </summary>
        /// <param name="mainBlock"></param>
        bool SetOwnership(IMainBlock mainBlock);
        bool SetOwnership(int mainBlockIndex);


    }
}
