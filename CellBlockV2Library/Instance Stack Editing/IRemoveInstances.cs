namespace CellBlockV2Library.Instance_Stack_Editing
{
    /// <summary>
    /// Used at the end of the solve method.
    /// Once a set of instances are finished with, the relevant instances must be removed from their stacks.
    /// </summary>
    public interface IRemoveInstances
    {
        /// <summary>
        /// Removes the top item from all Instances stacks that have height equal to the max stack height.
        /// </summary>
        void RemoveTopInstances();
    }
}