using System;
using System.Collections.Generic;
using Pathfinding.Interfaces;

namespace Pathfinding.Core
{
    public class BasePathfinder : IPathfind
    {
        public string[,] CreateNewGrid(int columns, int rows) {
            string[,] grid = new string[columns, rows];
            for (int y = 0; y < columns; y++) {
                for (int x = 0; x < rows; x++) {
                    grid[y, x] = ".";
                }
            }
            return grid;
        }

        public bool IsPositionInsideGrid(int gridColumns, int gridRows, params Vector2[] positions) {
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

        public List<Vector2> CardinalDirections {
            get {

                return new List<Vector2>() {
                    new Vector2(1, 0),
                    new Vector2(-1, 0),
                    new Vector2(0, 1),
                    new Vector2(0, -1)
                };
            }
        }

        public void PrintoutGrid(string[,] grid, int columns, int rows) {
            for (int y = columns - 1; y > -1; y--) {
                for (int x = 0; x < rows; x++) {
                    Console.Write(grid[y, x].ToString());
                }
                Console.WriteLine();
            }
        }

        protected List<Vector2> CreateListOfWalls(params Vector2[] walls) {
            List<Vector2> wallList = new List<Vector2>();
            foreach (Vector2 wall in walls) {
                wallList.Add(wall);
            }

            return wallList;
        }

        /// <summary>
        /// Runs the specified pathfinding algorithm, and prints out the result if successfull.
        /// </summary>
        /// <param name="columns">Amount of columns of the grid to traverse.</param>
        /// <param name="rows">Amount of rows of the grid to traverse.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="endPosition">The end position.</param>
        /// <param name="walls">Location of impassable "walls".</param>
        public virtual void Main(int columns, int rows, Vector2 startPosition, Vector2 endPosition, params Vector2[] walls) {
            
        }

        public void PrintFoundPath(List<Vector2> path, string[,] grid, int columns, int rows) {
            foreach (Vector2 position in path) {
                grid[position.y, position.x] = "X"; 
            }

            PrintoutGrid(grid, columns, rows);
        }

        protected void PrintoutPath(List<Vector2> path) {
            int counter = 0;
            string printout = "";
            foreach (Vector2 pos in path) {
                counter++;

                printout += string.Format("{0}-{1}", counter.ToString(), pos.ToString());
                //printout += ("{0, 3} - {1}", counter.ToString(), pos.ToString());
                //Console.WriteLine("{0, 3} - {1}", counter.ToString(), pos.ToString());
                if (counter != path.Count) {
                    printout += " | ";
                }
                else {
                    printout += ".";
                }
            }
            Console.WriteLine(printout);
        }

        protected void AddWallsToGrid(string[,] grid, Vector2[] walls) {
            foreach (Vector2 wall in walls) {
                grid[wall.y, wall.x] = "#";
            }
        }
    }
}
