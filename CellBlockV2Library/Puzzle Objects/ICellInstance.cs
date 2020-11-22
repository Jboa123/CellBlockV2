using System.Collections.Generic;

namespace CellBlockV2Library.Puzzle_Objects
{
    /// <summary>
    /// Stores data that may need to be copied and modified, retaining the original data.
    /// </summary>
    public interface ICellInstance
    {
        /// <summary>
        /// The MainBlock that owns this Cell.
        /// A null value represents no known owner.
        /// </summary>
        IMainBlock OwnedBy { get; set; }
        /// <summary>
        /// All the keys that remain in the PossibleOwners dictionary. Allows more effecient looping through PossibleOwners
        /// </summary>
        LinkedList<IMainBlock> PossibleMainBlocks { get; set; }
        /// <summary>
        /// Each int represents a possible block that contains this cell.
        /// The key is the MainBlock that the corresponding possible block belongs to.
        /// </summary>
        Dictionary<IMainBlock, LinkedList<int>> PossibleOwners { get; set; }
    }
}