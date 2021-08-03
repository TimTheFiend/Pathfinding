using Pathfinding.Interfaces;
using Pathfinding.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.PathfindingAlgorithm
{
    /// <summary>
    /// Pathfinding that goes to every possible location and retraces itself from the end back towards the starting point.
    /// <br></br>
    /// <see href="https://en.wikipedia.org/wiki/Breadth-first_search"/>
    /// </summary>
    /// <seealso cref="Pathfinding.PathfindingAlgorithm.Pathfinder" />
    public class BreadthFirstSearch : BasePathfinder
    {
        public override void Main(int columns, int rows, Vector2 startPosition, Vector2 endPosition, params Vector2[] walls) {
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

            //Decided to make it string values instead of ints for nicer printouts
            string[,] grid = CreateNewGrid(columns, rows);
            AddWallsToGrid(grid, walls);  //"Draw" the positions of the walls in the grid
            List<Vector2> wallList = CreateListOfWalls(walls);  //Turns the array into a list, for easier access later.

            //Queue up startPosition
            Queue<Vector2> frontier = new Queue<Vector2>();
            frontier.Enqueue(startPosition);

            //Create dictionary to keep track of pathfinding
            Dictionary<Vector2, Nullable<Vector2>> cameFrom = new Dictionary<Vector2, Vector2?>();
            cameFrom.Add(startPosition, null);  //null because we started here.

            // Travels all possible directions
            while (frontier.Count != 0) {
                Vector2 currentPosition = frontier.Dequeue();

                foreach (Vector2 direction in CardinalDirections) {
                    Vector2 nextPosition = currentPosition + direction;
                    //Vector2 nextPosition = new Vector2(currentPosition.x + direction.x, currentPosition.y + direction.y);
                    if (IsPositionInsideGrid(columns, rows, nextPosition)) {
                        // Can't move into walls
                        if (wallList.Contains(nextPosition)) {
                            continue;
                        }
                        if (!cameFrom.ContainsKey(nextPosition)) {
                            cameFrom.Add(nextPosition, currentPosition);
                            frontier.Enqueue(nextPosition);
                        }
                    }
                }
            }

            ///`cameFrom` should now contain a list of every single position on the grid
            ///And we can now walk back from the endPosition to startPosition
            Vector2 currentPathPosition = endPosition;
            List<Vector2> path = new List<Vector2>();

            while (currentPathPosition != startPosition) {
                path.Add(currentPathPosition);
                currentPathPosition = cameFrom[currentPathPosition].Value;
            }

            //Minor aesthetic choices
            path.Add(startPosition);
            path.Reverse();
            
            //Printout
            PrintFoundPath(path, grid, columns, rows);
            PrintoutPath(path);
        }
    }
}
