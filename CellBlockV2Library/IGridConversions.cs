using System.Collections.Generic;

namespace CellBlockV2Library
{
    public interface IGridConversions
    {
        int CartesianToListPosition(List<int> cartesianCoordinates);
    }
}