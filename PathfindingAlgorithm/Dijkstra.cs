using System;
using System.Collections.Generic;
using System.Text;
using Pathfinding.Core;

namespace Pathfinding.PathfindingAlgorithm
{
    public class Dijkstra : BasePathfinder
    {
        public override void Main(int columns, int rows, Vector2 startPosition, Vector2 endPosition, params Vector2[] walls) {
            //TODO: extract this method and make it seperate
            #region Validating user input
            List<Vector2> checkPositions = new List<Vector2>() { startPosition, endPosition };

            if (walls.Length > 0) {
                foreach (Vector2 position in walls) {
                    checkPositions.Add(position);
                }
            }
            if (!IsPositionInsideGrid(columns, rows, checkPositions.ToArray())) {
                Console.WriteLine("Invalid Vector2 values given.");
                return;
            }
            #endregion

            #region Non-unique
            PriorityQueue<Vector2> frontier = new PriorityQueue<Vector2>();
            frontier.Enqueue(startPosition, 0.0);

            Dictionary<Vector2, Nullable<Vector2>> cameFrom = new Dictionary<Vector2, Vector2?>();
            cameFrom.Add(startPosition, null);
            #endregion

            #region Randomly Generate Cost map
            Random rng = new Random();

            Grid<int> costGrid = new Grid<int>(rows, columns);
            for (int x = 0; x < costGrid.columns; x++) {
                for (int y = 0; y < costGrid.rows; y++) {
                    costGrid[x, y] = rng.Next(1, 9);
                }
            }
            #endregion

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
                    if (IsPositionInsideGrid(columns, rows, nextPosition)) {

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
            #endregion

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
            #endregion
        }
    }
}
