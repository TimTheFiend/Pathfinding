﻿using System;
using PathfindingAttempt.Core;
using PathfindingAttempt.PathfindingAlgorithm;

namespace PathfindingAttempt
{
    class Program
    {
        static void Main(string[] args) {


            int columns = 20;
            int rows = 10;
            Vector2 startPosition = new Vector2(0, 0);
            Vector2 endPosition = new Vector2(8, 7);

            Grid grid = new Grid(rows, columns);

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

            int input = 0;
            
            while (true) {
                Console.WriteLine("1: Breadth-first Search");
                Console.WriteLine("2: Early Exit (Based on Breadth-First search)");
                Console.Write("Please select which pathfinding algorithm you want to use, escape for exit: ");
                ConsoleKeyInfo name = Console.ReadKey();

                if (name.Key == ConsoleKey.Escape) {
                    return;
                }

                string stringInput = name.KeyChar.ToString();
                if (Int32.TryParse(stringInput, out input)) {

                    break;
                }
                Console.Clear();
            }
            Console.Clear();

            switch (input) {
                case 1:
                    new BreadthFirstSearch().Main(columns, rows, startPosition, endPosition, walls);
                    break;
                case 2:
                    new EarlyExit().Main(columns, rows, startPosition, endPosition, walls);
                    break;
                default:
                    break;
            }



            return;
        }
    }
}
