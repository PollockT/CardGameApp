using System.Collections.Generic;

namespace CardGameUI
{
    public class BlackJack : DeckClass
    {
        public BlackJack()
        {
            CreateDeck();
            ShuffleDeck();
        }

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
}
