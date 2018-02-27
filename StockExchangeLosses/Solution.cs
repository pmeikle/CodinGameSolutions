using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeLosses
{
    class Solution
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stockPrices = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();

            var maxLoss = 0;
            var maxPriceSoFar = 0;

            for (var i = 0; i < n; i++)
            {
                var currentPrice = stockPrices.ElementAt(i);
                if (currentPrice > maxPriceSoFar)
                    maxPriceSoFar = currentPrice;
                else if (currentPrice - maxPriceSoFar < maxLoss)
                    maxLoss = currentPrice - maxPriceSoFar;

            }

            Console.WriteLine(maxLoss);
        }
    }
}
