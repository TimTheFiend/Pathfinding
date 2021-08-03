using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingAttempt.Core
{
    public struct GraphGrid
    {
        public int[,] grid;

        public GraphGrid(int gridRows, int gridColumns) {
            grid = new int[gridColumns, gridRows];
        }

    }
}
