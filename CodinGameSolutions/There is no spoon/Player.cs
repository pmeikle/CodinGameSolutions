using System;
using System.Collections.Generic;
using System.Linq;

namespace CodinGameSolutions.There_is_no_spoon
{
    class Player
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
            var nodes = new List<Point>();
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine(); // width characters, each either 0 or .
                for (int j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    if(character == '0')
                        nodes.Add(new Point(){X = j, Y = i});
                }

                //Console.WriteLine(line);
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            var defaultNode = new Point(){X = -1, Y = -1};
            nodes.ForEach(node =>
            {
                var rightNeighbor = nodes.FirstOrDefault(n => n.X > node.X && n.Y == node.Y) ?? defaultNode;

                var bottomNeighbor = nodes.FirstOrDefault(n => n.X == node.X && n.Y > node.Y) ?? defaultNode;

                Console.WriteLine($"{node.X} {node.Y} {rightNeighbor.X} {rightNeighbor.Y} {bottomNeighbor.X} {bottomNeighbor.Y}");
            });

            // Three coordinates: a node, its right neighbor, its bottom neighbor
            Console.WriteLine("0 0 1 0 0 1");
        }
    }


    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
