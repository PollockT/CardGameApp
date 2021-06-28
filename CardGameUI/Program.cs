using System;
using System.Text;
using System.Threading.Tasks;

namespace CardGameUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJack deck = new BlackJack();

            var hand = deck.DealCards();
            foreach (var card in hand)
            {
                Console.WriteLine($"{ card.Value } of { card.Suit }");
            }
            
            Console.ReadLine();
        }
    }
}
