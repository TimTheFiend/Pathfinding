using System;
using System.Collections.Generic;
using Pathfinding.Core;

namespace Pathfinding.PathfindingAlgorithm
{
    /// <summary>
    /// Heuristic does not care about how costly it is to get to the `endPosition`, it's only concerned with taking the path
    /// that's most likely to get there as soon as possible.<br></br>
    /// In a seeded(111193) weighted grid, it took 18 moves to get to `endPosition`, compared to Breadth, Early Exit(EE), and Dijkstra,
    /// that explores every possible direction, EE being slightly different in stopping when `endPosition` has been discovered.
    /// </summary>
    /// <seealso cref="Pathfinding.Core.BasePathfinder" />
    public class Heuristic : BasePathfinder
    {
        public override void Main(int columns,
            int rows,
            Vector2 startPosition,
            Vector2 endPosition,
            int randomSeed = 0,
            params Vector2[] walls) {
            //TODO: extract this method and make it seperate
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
            #endregion

            #region Non-unique
            PriorityQueue<Vector2> frontier = new PriorityQueue<Vector2>();
            frontier.Enqueue(startPosition, 0.0);

            Dictionary<Vector2, Nullable<Vector2>> cameFrom = new Dictionary<Vector2, Vector2?>();
            cameFrom.Add(startPosition, null);
            #endregion

            #region Randomly Generate Cost map
            Random rng = GetRandom(randomSeed);

            Grid<int> costGrid = new Grid<int>(rows, columns);
            for (int x = 0; x < costGrid.columns; x++) {
                for (int y = 0; y < costGrid.rows; y++) {
                    costGrid[x, y] = rng.Next(1, 9);
                }
            }
            #endregion


            while (frontier.Count >= 0) {
                Vector2 currentPosition = frontier.Dequeue();

                if (currentPosition == endPosition) {
                    break;
                }

                foreach (Vector2 direction in CardinalDirections) {
                    Vector2 nextPosition = new Vector2(currentPosition + direction);
                    if (IsPositionInsideGrid(columns, rows, nextPosition)) {
                        if (!cameFrom.ContainsKey(nextPosition)) {  //TODO adds walls
                            int priority = GetHeuristic(endPosition, nextPosition);
                            frontier.Enqueue(nextPosition, priority);
                            cameFrom.Add(nextPosition, currentPosition);
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
