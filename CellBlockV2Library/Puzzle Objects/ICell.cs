using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public interface ICell
    {

        ICollection PossibleOwners { get; set; }
     
        /// <summary>
        /// The Cartesian coordinates of the cell starting with x-pos at index 0;
        /// </summary>
        List<int> Coordinates { get; set; }

        int OwnedBy { get; set; }

        bool IsOwnedByBlockOtherThan(IMainBlock mainBlock);
        bool IsOwnedByBlockOtherThan(int mainBlockIndex);
        void SetOwnship(IMainBlock mainBlock);
        void SetOwnship(int mainBlockIndex);


    }
}
