using System;
using Pathfinding.Core;
using Pathfinding.PathfindingAlgorithm;

namespace Pathfinding
{
    internal class Program
    {
        private static void Main(string[] args) {

            #region input variables

            int columns = 20;
            int rows = 20;
            int rngSeed = 111193;
            Vector2 startPosition = new Vector2(0, 0);
            Vector2 endPosition = new Vector2(17, 15);

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

            #endregion input variables

            #region Choice menu

            int input = 0;

            while (true) {
                Console.WriteLine("1: Breadth-first Search");
                Console.WriteLine("2: Early Exit (Based on Breadth-First search)");
                Console.WriteLine("3: Dijkstra");
                Console.WriteLine("4: Heuristic");
                Console.WriteLine("5: A* (A Star)");
                Console.Write("Please select which pathfinding algorithm you want to use, escape for exit: ");
                ConsoleKeyInfo name = Console.ReadKey();

                if (name.Key == ConsoleKey.Escape) {
                    return;
                }

                string stringInput = name.KeyChar.ToString();
                if (Int32.TryParse(stringInput, out input)) {
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }

            BasePathfinder pathfinderToRun = new BasePathfinder();
            switch (input) {
                case 1:
                    pathfinderToRun = new BreadthFirstSearch();
                    break;

                case 2:
                    pathfinderToRun = new EarlyExit();
                    break;

                case 3:
                    pathfinderToRun = new Dijkstra();
                    break;

                case 4:
                    pathfinderToRun = new Heuristic();
                    break;

                case 5:
                    pathfinderToRun = new AStar();
                    break;

                default:
                    break;
            }

            pathfinderToRun.Main(columns, rows, startPosition, endPosition, rngSeed, walls);

            #endregion Choice menu
        }
    }
}