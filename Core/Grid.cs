using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Core
{
    public struct Grid<T>
    {
        public T[,] grid;
        public Vector2 dimensions;
        public int rows;
        public int columns;

        public Grid(int rows, int columns) {
            grid = new T[columns, rows];
            dimensions = new Vector2(rows, columns);
            this.rows = rows;
            this.columns = columns;
        }

        public void Print() {
            for (int x = columns - 1; x >= 0; x--) {
                string printout = "";
                for (int y = 0; y < rows; y++) {
                    printout += grid[x, y];
                }
                Console.WriteLine(printout);
            }
        }

        public T this[int x, int y] {
            get {
                return grid[y, x];
            }
            set {
                grid[y, x] = value;
            }
        }
    }
}
