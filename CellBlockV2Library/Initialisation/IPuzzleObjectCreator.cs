namespace CellBlockV2Library
{
    /// <summary>
    /// Responsible for creating the Cells and MainBlocks during initialisation of the program.
    /// </summary>
    public interface IPuzzleObjectCreator
    {
        /// <summary>
        /// Creates all the Cells, equal to the capacity of the Grid, given by the user.
        /// Sets the Coorindates property. The first item is created and added to the Istances stack upon construction of the Cell.
        /// </summary>
        void CreateCells();
        /// <summary>
        /// Creates all the MainBlock, equal to the number of PredefinedCells, given by the user.
        /// Sets the Capacity, Index and PredefinedCell properties. The first item is created and added to the Istances stack upon construction of the MainBlock.
        /// </summary>
        void CreateMainBlocks();
    }
}