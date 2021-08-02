using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace PathfindingAttempt
{
    public class AStar
    {
        int hi = 5;
        int rows = 10;
        int columns = 10;

        Vector2 startPosition = new Vector2(5, 5);
        Vector2 endPosition = new Vector2(8, 7);

        public List<Vector2> cardinalDirections {
            get {
                return new List<Vector2>() {
                    new Vector2(1, 0),
                    new Vector2(-1, 0),
                    new Vector2(0, 1),
                    new Vector2(0, -1)
                };
            }
        }

        public AStar() { }

        public void BreadthFirstSearch() {
            int[,] grid = new int[columns, rows];

            grid[0, 6] = 9;
            grid[1, 6] = 9;
            grid[2, 6] = 9;
            grid[3, 6] = 9;
            grid[4, 6] = 9;
            grid[5, 6] = 9;
            grid[6, 6] = 9;
            grid[7, 6] = 9;
            grid[8, 6] = 9;
            

            Console.WriteLine(grid.Length);
            for (int col = 0; col < rows; col++) {
                string printout = "";
                for (int row = 0; row < columns; row++) {
                    printout += grid[col, row].ToString();
                }
                Console.WriteLine(printout);
            }

            Queue<Vector2> frontier = new Queue<Vector2>();
            frontier.Enqueue(startPosition);

            Dictionary<Vector2, Nullable<Vector2>> cameFrom = new Dictionary<Vector2, Vector2?>();
            cameFrom.Add(startPosition, null);

            while (frontier.Count != 0) {
                Vector2 _currentPosition = frontier.Dequeue();
                foreach (Vector2 direction in cardinalDirections) {
                    Vector2 nextDirection = new Vector2(_currentPosition.x + direction.x, _currentPosition.y + direction.y);
                    if (nextDirection.x > columns - 1 || nextDirection.y > rows - 1 || nextDirection.x < 0 || nextDirection.y < 0 || grid[nextDirection.y, nextDirection.x] == 9) {
                        continue;
                    }

                    if (!cameFrom.ContainsKey(nextDirection)) {
                        cameFrom.Add(nextDirection, _currentPosition);
                        frontier.Enqueue(nextDirection);
                    }
                }
            }

            Vector2 currentPosition = endPosition;
            List<Vector2> path = new List<Vector2>();
            int counter = 0;
            while (!currentPosition.Equals(startPosition)) {
                path.Add(currentPosition);
                currentPosition = cameFrom[currentPosition].Value;
                counter++;
            }
            path.Add(startPosition);
            path.Reverse();
            foreach (Vector2 pathway in path) {
                Console.WriteLine(pathway);
            }

        }


        public void EarlyExit() {
            int[,] grid = new int[columns, rows];

            grid[0, 6] = 9;
            grid[1, 6] = 9;
            grid[2, 6] = 9;
            grid[3, 6] = 9;
            grid[4, 6] = 9;
            grid[5, 6] = 9;
            grid[6, 6] = 9;
            grid[7, 6] = 9;
            grid[8, 6] = 9;


            Console.WriteLine(grid.Length);
            for (int col = 0; col < rows; col++) {
                string printout = "";
                for (int row = 0; row < columns; row++) {
                    printout += grid[col, row].ToString();
                }
                Console.WriteLine(printout);
            }

            Queue<Vector2> frontier = new Queue<Vector2>();
            frontier.Enqueue(startPosition);

            Dictionary<Vector2, Nullable<Vector2>> cameFrom = new Dictionary<Vector2, Vector2?>();
            cameFrom.Add(startPosition, null);

            while (frontier.Count != 0) {
                Vector2 _currentPosition = frontier.Dequeue();
                foreach (Vector2 direction in cardinalDirections) {
                    Vector2 nextDirection = new Vector2(_currentPosition.x + direction.x, _currentPosition.y + direction.y);

                    if (nextDirection.x > columns - 1 || nextDirection.y > rows - 1 || nextDirection.x < 0 || nextDirection.y < 0 || grid[nextDirection.y, nextDirection.x] == 9) {
                        continue;
                    }

                    if (!cameFrom.ContainsKey(nextDirection)) {
                        cameFrom.Add(nextDirection, _currentPosition);
                        frontier.Enqueue(nextDirection);
                        if (nextDirection.Equals(endPosition)) {
                            break; //Note: Only difference between EarlyExit & Breadth
                        }
                    }
                }
            }

            Vector2 currentPosition = endPosition;
            List<Vector2> path = new List<Vector2>();
            int counter = 0;
            while (!currentPosition.Equals(startPosition)) {
                path.Add(currentPosition);
                currentPosition = cameFrom[currentPosition].Value;
                counter++;
            }
            path.Add(startPosition);
            path.Reverse();
            foreach (Vector2 pathway in path) {
                Console.WriteLine(pathway);
            }

        }

    }

    public struct Vector2
    {
        public int x, y;

        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Vector2 other) {
            return this.x == other.x && this.y == other.y;
        }

        public override string ToString() {
            return $"({x},{y})";
        }
    }
}
