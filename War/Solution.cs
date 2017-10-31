using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Solution
    {
        static void Main(string[] args)
        {
            var player1Cards = new Queue<String>();
            var player2Cards = new Queue<String>();
            int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
            for (int i = 0; i < n; i++)
            {
                string cardp1 = Console.ReadLine(); // the n cards of player 1
                player1Cards.Enqueue(cardp1);
            }
            int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
            for (int i = 0; i < m; i++)
            {
                string cardp2 = Console.ReadLine(); // the m cards of player 2
                player2Cards.Enqueue(cardp2);
            }

            PlayWar(player1Cards, player2Cards);
            
        }

        public static void PlayWar(Queue<string> player1Cards, Queue<string> player2Cards)
        {
            var rounds = 0;

            while (player1Cards.Count > 0 && player2Cards.Count > 0)
            {
                var player1CardsInPlay = new Queue<String>();
                var player2CardsInPlay = new Queue<String>();

                var player1Card = player1Cards.Dequeue();
                var player1CardValue = GetCardValue(player1Card);
                var player2Card = player2Cards.Dequeue();
                var player2CardValue = GetCardValue(player2Card);

                player1CardsInPlay.Enqueue(player1Card);
                player2CardsInPlay.Enqueue(player2Card);

                while (player1CardValue == player2CardValue)
                {
                    if (player1Cards.Count < 4 || player2Cards.Count < 4)
                    {
                        Console.WriteLine("PAT");
                        return;
                    }
                    player1CardsInPlay.Enqueue(player1Cards.Dequeue());
                    player1CardsInPlay.Enqueue(player1Cards.Dequeue());
                    player1CardsInPlay.Enqueue(player1Cards.Dequeue());

                    player2CardsInPlay.Enqueue(player2Cards.Dequeue());
                    player2CardsInPlay.Enqueue(player2Cards.Dequeue());
                    player2CardsInPlay.Enqueue(player2Cards.Dequeue());

                    player1Card = player1Cards.Dequeue();
                    player1CardsInPlay.Enqueue(player1Card);
                    player2Card = player2Cards.Dequeue();
                    player2CardsInPlay.Enqueue(player2Card);

                    player1CardValue = GetCardValue(player1Card);
                    player2CardValue = GetCardValue(player2Card);
                }

                var winnersCards = player1CardValue > player2CardValue ? player1Cards : player2Cards;

                while(player1CardsInPlay.Count > 0)
                    winnersCards.Enqueue(player1CardsInPlay.Dequeue());

                while(player2CardsInPlay.Count > 0)
                    winnersCards.Enqueue(player2CardsInPlay.Dequeue());
                    

                rounds++;
            }
            Console.WriteLine($"{(player1Cards.Count > 0 ? 1 : 2)} {rounds}");
        }

        public static int GetCardValue(string card)
        {
            return int.Parse(card.Substring(0, card.Length-1).Replace("J", "11").Replace("Q", "12").Replace("K", "13").Replace("A", "14"));
        }
    }
}
