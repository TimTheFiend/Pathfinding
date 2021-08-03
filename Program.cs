using System;
using PathfindingAttempt.Core;
using PathfindingAttempt.PathfindingAlgorithm;

namespace PathfindingAttempt
{
    class Program
    {
        static void Main(string[] args) {
            int columns = 10;
            int rows = 10;
            Vector2 startPosition = new Vector2(0, 0);
            Vector2 endPosition = new Vector2(8, 7);

            
            Vector2[] walls = new Vector2[] {
                new Vector2(1, 8),
                new Vector2(2, 7),
                new Vector2(3, 6),
                new Vector2(4, 5),
                new Vector2(5, 4),
                new Vector2(6, 3),
                new Vector2(7, 2),
                new Vector2(8, 1)
            };

            new BreadthFirstSearch().Main(columns, rows, startPosition, endPosition, walls);


            return;
        }
    }
}
