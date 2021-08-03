using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingAttempt.Core
{
    public static class SanityCheck
    {
        public static bool IsPositionInsideGrid(int gridColumns, int gridRows, params Vector2[] positions) {
            Vector2 gridSize = new Vector2(gridRows - 1, gridColumns - 1);

            foreach (Vector2 position in positions) {
                if (position.x >= 0 && position.y >= 0 && position.x <= gridSize.x && position.y <= gridSize.y) {
                }
                else {
                    return false;
                }
            }
            return true;
        }

        public static int[,] CreateNewGrid(int columns, int rows) {
            return new int[columns, rows];
        }

        public static List<Vector2> CardinalDirections() {
            return new List<Vector2>() {
                    new Vector2(1, 0),
                    new Vector2(-1, 0),
                    new Vector2(0, 1),
                    new Vector2(0, -1)
                };
        }

        public static void PrintoutGrid(int[,] grid, int columns, int rows) {
            for (int y = 0; y < columns; y++) {
                for (int x = 0; x < rows; x++) {
                    Console.Write(grid[y, x].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
