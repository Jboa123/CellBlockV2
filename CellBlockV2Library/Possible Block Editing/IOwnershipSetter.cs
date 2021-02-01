using CellBlockV2Library.Puzzle_Objects;

namespace CellBlockV2Library.Possible_Block_Editing
{
    public interface IOwnershipSetter
    {
        bool ChangeHasOccured { get; set; }
        bool MarkCellAsOwned(ICell cell, IMainBlock mainBlock);
        bool SetPossibleBlockAsSolution(IPossibleBlock possibleBlock);
    }
}