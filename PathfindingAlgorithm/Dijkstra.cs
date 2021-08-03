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

            PriorityQueue<Vector2> frontier = new PriorityQueue<Vector2>();
            frontier.Enqueue(startPosition, 0.0);

            Dictionary<Vector2, Nullable<Vector2>> cameFrom = new Dictionary<Vector2, Vector2?>();
            cameFrom.Add(startPosition, null);

            Dictionary<Vector2, double> movementCost = new Dictionary<Vector2, double>();
            movementCost.Add(startPosition, 0.0);

            while (frontier.Count >= 0) {
                Vector2 currentPosition = frontier.Dequeue();

                if (currentPosition == endPosition) {
                    break;
                }

                foreach (Vector2 direction in CardinalDirections) {
                    double newCost = movementCost[currentPosition];
                }
            }
        }
    }
}
