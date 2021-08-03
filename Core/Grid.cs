using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingAttempt.Core
{
    public struct Grid
    {
        public string[,] grid;
        public Vector2 dimensions;
        public int rows;
        public int columns;

        public Grid(int rows, int columns) {
            grid = new string[columns, rows];
            dimensions = new Vector2(rows, columns);
            this.rows = rows;
            this.columns = columns;

            ResetGrid();
        }

        public void ResetGrid() {
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < columns; x++) {
                    Vector2 temp = new Vector2(x, y);
                    grid[x, y] = ".";
                }
            }
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

        public string this[int x, int y] {
            get {
                return grid[y, x];
            }
            set {
                grid[y, x] = value;
            }
        }
    }
}
