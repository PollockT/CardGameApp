using System.Collections.Generic;

namespace CardGameUI
{
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
