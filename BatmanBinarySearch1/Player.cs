using System;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
namespace BatmanBinarySearch1
{
    class Player
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ');
            var W = int.Parse(inputs[0]); // width of the building.
            var H = int.Parse(inputs[1]); // height of the building.
            var N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
            inputs = Console.ReadLine().Split(' ');
            var batmanX = int.Parse(inputs[0]);
            var batmanY = int.Parse(inputs[1]);

            var left = 0;
            var right = W - 1;
            var bottom = H - 1;
            var top = 0;

            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                Console.Error.WriteLine($"batmanX:{batmanX} batmanY:{batmanY}");
                Console.Error.WriteLine($"left:{left} right:{right} bottom:{bottom} top:{top}");

                if (bombDir == "U")
                {
                    left = batmanX;
                    right = batmanX;
                    bottom = batmanY - 1;
                }
                else if (bombDir == "D")
                {
                    left = batmanX;
                    right = batmanX;
                    top = batmanY + 1;
                }
                else if (bombDir == "R")
                {
                    top = batmanY;
                    bottom = batmanY;
                    left = batmanX + 1;
                }
                else if (bombDir == "L")
                {
                    top = batmanY;
                    bottom = batmanY;
                    right = batmanX - 1;
                }
                else if (bombDir == "UR")
                {
                    bottom = batmanY - 1;
                    left = batmanX + 1;
                }
                else if (bombDir == "DR")
                {
                    top = batmanY + 1;
                    left = batmanX + 1;
                }
                else if (bombDir == "UL")
                {
                    bottom = batmanY - 1;
                    right = batmanX - 1;
                }
                else if (bombDir == "DL")
                {
                    top = batmanY + 1;
                    right = batmanX - 1;
                }

                batmanX = (left + right) / 2;
                batmanY = (bottom + top) / 2;

                // the location of the next window Batman should jump to.
                Console.WriteLine($"{batmanX} {batmanY}");
            }
        }
    }
}