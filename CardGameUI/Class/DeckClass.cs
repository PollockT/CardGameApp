using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameUI
{
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
            drawPile = fullDeck.OrderBy(x => rnd.Next()).ToList();
        }

        public abstract List<PlayingCardClass> DealCards();

        protected virtual PlayingCardClass DrawOneCard()
        {
            PlayingCardClass output = drawPile.Take(1).First();
            drawPile.Remove(output);
            return output;
        }

    }
}
