using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library.Puzzle_Objects
{ 
        /// <summary>
        /// Stores data that may need to be copied and modified, retaining the original data.
        /// </summary>
    public class CellInstance : ICellInstance
    {
        /// <summary>
        /// The MainBlock that owns this Cell.
        /// </summary>
        public IMainBlock OwnedBy { get; set; }
        /// <summary>
        /// All the keys that remain in the PossibleOwners dictionary.
        /// </summary>
        public LinkedList<IMainBlock> PossibleMainBlocks { get; set; } = new LinkedList<IMainBlock>();
        /// <summary>
        /// Each int represents a possible block that contains this cell.
        /// The key is the MainBlock that the corresponding possible block belongs to.
        /// </summary>
        public Dictionary<IMainBlock, LinkedList<int>> PossibleOwners { get; set; } = new Dictionary<IMainBlock, LinkedList<int>>();
    }
}
