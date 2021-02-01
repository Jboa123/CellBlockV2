using CellBlockV2Library.Puzzle_Objects;

namespace CellBlockV2Library
{

    /// <summary>
    /// Used to create new CellInstance and MainBlockInstances.
    /// Required when removing possible blocks doesn't find a solution nor prove there isn't one.
    /// </summary>
    public interface ICloneData
    {
        
        /// <summary>
        /// Adds a new instance to the stack of each Cell and MainBlock with no known solution.
        /// Copies relevant data from the original Instance on the stack.
        /// </summary>
        void CloneInstancesAndData();
    }
}