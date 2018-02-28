using System;
using System.Linq;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
namespace TheLastCrusadeEp1
{
    public class Player
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // number of columns.
            int H = int.Parse(inputs[1]); // number of rows.

            var gameBoard = new int[H, W];
            for (int i = 0; i < H; i++)
            {
                var row = Console.ReadLine().Split(' ').Select(Int32.Parse);
                for (int j = 0; j < W; j++)
                {
                    gameBoard[i, j] = row.ElementAt(j);
                }
            }
            
            int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                int XI = int.Parse(inputs[0]);
                int YI = int.Parse(inputs[1]);
                string POS = inputs[2];

                var cellType = gameBoard[YI, XI];
                Console.Error.WriteLine("type: " + cellType);
                if (cellType == 6 || cellType == 2)
                {
                    if (POS == "RIGHT")
                        XI--;
                    else
                        XI++;
                }
                else if (cellType == 10 || (cellType == 4 && POS == "TOP"))
                {
                    XI--;
                }
                else if (cellType == 11 || (cellType == 5 && POS == "TOP"))
                {
                    XI++;
                }
                else
                {
                    YI++;
                }

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");


                // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
                Console.WriteLine($"{XI} {YI}");
            }
        }
    }
}