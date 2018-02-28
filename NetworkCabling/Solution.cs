using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        var maxX = Int64.MinValue;
        var minX = Int64.MaxValue;
        var ys = new List<Int64>();
        //var sumYs = (Int64) 0;

        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            var X = Int64.Parse(inputs[0]);
            var Y = Int64.Parse(inputs[1]);

            if (X > maxX) maxX = X;
            
            if (X < minX) minX = X;
            //sumYs += Y;
            ys.Add(Y);
        }

        var verticalYSums = VerticalLengthsSum(ys);

        Console.WriteLine((maxX - minX + verticalYSums));
    }

    private static Int64 VerticalLengthsSum(List<long> ys)
    {
        var orderedYs = ys.OrderBy(y => y).ToList();
        var medianY = orderedYs[orderedYs.Count() / 2];
        return ys.Sum(y => Math.Abs(medianY - y));
    }
}