using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine($"{ card.Suit.ToString() } of { card.Value.ToString() }");
            }
            
            Console.ReadLine();
        }
    }

    public abstract class DeckClass
    {

        //Everything must pull from the same deck created!
        protected List<PlayingCardClass> fullDeck = new List<PlayingCardClass>();
        protected List<PlayingCardClass> drawPile = new List<PlayingCardClass>();
        protected List<PlayingCardClass> discardPile = new List<PlayingCardClass>();

        protected void CreateDeck()
        {
            fullDeck.Clear(); //flush any previous deck holdings

            for (int suit = 0; suit < 4; suit++)
            {
                for (int val = 0; val < 13; val++)
                {
                    fullDeck.Add(new PlayingCardClass { Suit = (ECardSuit)suit, Value = (ECardValue)val });
                }
            }
        }

        public virtual void ShuffleDeck()
        {
            var rnd = new Random();
            var drawPile = fullDeck.OrderBy(x => rnd.Next()).ToList();
        }

        public abstract List<PlayingCardClass> DealCards();

        protected virtual PlayingCardClass DrawOneCard()
        {
            PlayingCardClass output = drawPile.Take(1).First();
            drawPile.Remove(output);
            return output;
        }

    }
    public class BlackJack : DeckClass
    {
        public override List<PlayingCardClass> DealCards()
        {
            List<PlayingCardClass> output = new List<PlayingCardClass>();
            for (int i = 0; i < 2; i++)
            {
                output.Add(DrawOneCard());
            }
            return output;
        }

        public PlayingCardClass RequestCard()
        {
            return DrawOneCard();
        }
    }

    public class PokerDeck : DeckClass
    {
        public PokerDeck()
        {
            CreateDeck();
            ShuffleDeck();
        }

        public override List<PlayingCardClass> DealCards()
        {
            List<PlayingCardClass> output = new List<PlayingCardClass>();
            for (int i = 0; i < 5; i++)
            {
                output.Add(DrawOneCard());
            }
            return output;
        }
        public List<PlayingCardClass> RequestCards(List<PlayingCardClass> cardsToDiscard)
        {
            List<PlayingCardClass> output = new List<PlayingCardClass>();
            foreach (var card in cardsToDiscard)
            {
                output.Add(DrawOneCard());
                discardPile.Add(card);
            }
            return output;
        }
    }
}
