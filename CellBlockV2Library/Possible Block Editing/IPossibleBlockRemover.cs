using CellBlockV2Library.Puzzle_Objects;
using System.Collections.Generic;

namespace CellBlockV2Library.Possible_Block_Editing
{
    public interface IPossibleBlockRemover
    {
        List<IMainBlock> RemoveImpossibleBlocks(ICell cell, IMainBlock mainBlock);

        void SetOwnerMainBlockPossibleBlocks(ICell cell, IMainBlock mainBlock);
    }
}