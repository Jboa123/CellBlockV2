using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{
    public class CellInstance : ICellInstance
    {
        /// <summary>
        /// The MainBlock that owns this Cell.
        /// </summary>
        public IMainBlock OwnedBy { get; set; }
        /// <summary>
        /// All the keys that remain in the PossibleOwners dictionary.
        /// </summary>
        public LinkedList<IMainBlock> PossibleMainBlocks { get; set; }
        /// <summary>
        /// Each int represents a possible block that contains this cell.
        /// The key is the MainBlock that the corresponding possible block belongs to.
        /// </summary>
        public Dictionary<IMainBlock, LinkedList<int>> PossibleOwners { get; set; }
    }
}
