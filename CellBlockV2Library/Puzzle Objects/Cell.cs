using CellBlockV2Library.Puzzle_Objects;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace CellBlockV2Library.Puzzle_Objects
{
    class Cell : ICell
    {
        // private readonly Grid Grid;
        public ICollection PossibleOwners { get; set; } = new Dictionary<int, List<IPossibleBlock>>();
        public List<int> Coordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int OwnedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsOwnedByBlockOtherThan(IMainBlock mainBlock)
        {
            throw new NotImplementedException();
        }

        public bool IsOwnedByBlockOtherThan(int mainBlockIndex)
        {
            throw new NotImplementedException();
        }

        public void SetOwnship(IMainBlock mainBlock)
        {
            throw new NotImplementedException();
        }

        public void SetOwnship(int mainBlockIndex)
        {
            throw new NotImplementedException();
        }
    }
}
