using System;
using System.Collections.Generic;
using Pathfinding.Core;

namespace Pathfinding.PathfindingAlgorithm
{
    /// <summary>
    /// Similarly to Breadth-First Search, Dijkstra's algorithm explores every possible direction on a weighted grid,
    /// ie. a grid where each position has a value assigned to it, signifying the cost to move into that space.<br></br>
    /// Dijkstra is concerned with finding the most efficient route to `endPosition`,
    /// retracing it's found path based on cost efficiency instead of the route with the fewest moves.
    /// </summary>
    /// <seealso cref="Pathfinding.Core.BasePathfinder" />
    public class Dijkstra : BasePathfinder
    {
        public override void Main(int columns,
            int rows,
            Vector2 startPosition,
            Vector2 endPosition,
            int randomSeed = 0,
            params Vector2[] walls) {  //TODO: extract this method and make it seperate

            #region Validating user input

            List<Vector2> checkPositions = new List<Vector2>() { startPosition, endPosition };

            List<Vector2> wallList = new List<Vector2>();

            if (walls.Length > 0) {
                wallList = CreateListOfWalls(walls);
                foreach (Vector2 position in walls) {
                    checkPositions.Add(position);
                }
            }
            if (!IsPositionInsideGrid(columns, rows, checkPositions.ToArray())) {
                Console.WriteLine("Invalid Vector2 values given.");
                return;
            }

            #endregion Validating user input

            #region Non-unique

            PriorityQueue<Vector2> frontier = new PriorityQueue<Vector2>();
            frontier.Enqueue(startPosition, 0.0);

            Dictionary<Vector2, Nullable<Vector2>> cameFrom = new Dictionary<Vector2, Vector2?>();
            cameFrom.Add(startPosition, null);

            #endregion Non-unique

            #region Randomly Generate Cost map

            Random rng = GetRandom(randomSeed);

            Grid<int> costGrid = new Grid<int>(rows, columns);
            for (int x = 0; x < costGrid.columns; x++) {
                for (int y = 0; y < costGrid.rows; y++) {
                    if (wallList.Contains(new Vector2(x, y))) {
                        costGrid[x, y] = 0;
                        continue;
                    }
                    costGrid[x, y] = rng.Next(1, 9);
                }
            }

            #endregion Randomly Generate Cost map

            //`movementCost` contains the cost of any given position, and the cost to get there
            Dictionary<Vector2, double> movementCost = new Dictionary<Vector2, double>();
            movementCost.Add(startPosition, 0.0);

            while (frontier.Count >= 0) {
                Vector2 currentPosition = frontier.Dequeue();

                if (currentPosition == endPosition) {
                    break;
                }

                foreach (Vector2 direction in CardinalDirections) {
                    Vector2 nextPosition = new Vector2(currentPosition + direction);
                    if (IsPositionInsideGrid(columns, rows, nextPosition) && !wallList.Contains(nextPosition)) {
                        //The movementCost to get here from `startPosition`
                        double newCost = movementCost[currentPosition] + costGrid[nextPosition];

                        if (!movementCost.ContainsKey(nextPosition) || newCost < movementCost[nextPosition]) {
                            movementCost[nextPosition] = newCost;

                            double priority = newCost;
                            frontier.Enqueue(nextPosition, priority);
                            cameFrom[nextPosition] = currentPosition;
                        }
                    }
                }
            }

            #region Non-unique

            Vector2 currentPathPosition = endPosition;
            List<Vector2> path = new List<Vector2>();

            while (currentPathPosition != startPosition) {
                path.Add(currentPathPosition);
                currentPathPosition = cameFrom[currentPathPosition].Value;
            }

            //Minor aesthetic choices
            path.Add(startPosition);
            path.Reverse();

            #endregion Non-unique

            #region Drawing

            //Only prints out the `costGrid`
            for (int y = 0; y < costGrid.columns; y++) {
                string printout = "";
                for (int x = 0; x < costGrid.rows; x++) {
                    printout += costGrid[x, y].ToString();
                }
                Console.WriteLine(printout);
            }

            Console.WriteLine();

            //Prints out the path on top of the `costGrid`. This is to see the route, and to check if it's the least expensive route.
            for (int y = 0; y < costGrid.columns; y++) {
                string printout = "";
                for (int x = 0; x < costGrid.rows; x++) {
                    if (path.Contains(new Vector2(x, y))) {
                        printout += "X";
                        continue;
                    }
                    printout += costGrid[x, y].ToString();
                }
                Console.WriteLine(printout);
            }

            PrintoutPath(path);

            #endregion Drawing
        }
    }
}