namespace CellBlockV2Library
{
    public interface ICreatePuzzleObjects
    {
        IPuzzleData _puzzleData { get; set; }
        ISolutionTracker _solutionTracker { get; set; }
    }
}