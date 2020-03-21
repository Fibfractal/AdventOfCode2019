using System.Collections.Generic;

namespace Advent_code_3
{
    public class GridPoint
    {
        public List<PathInfo> PassInfo { get; set; } = new List<PathInfo>();
        public List<int> DistanceToPoint { get; set; } = new List<int>();

        public int RowNbr { get; set; }
        public int ColumnNumber { get; set; }
    }
}
