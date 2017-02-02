using System.Collections.Generic;

namespace HandChooser
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();

            Initialize();
        }

        public List<Card> Cards { get; set; }

        private void Initialize()
        {
            Initialize(new Suit("Spade"));
            Initialize(new Suit("Diamond"));
            Initialize(new Suit("Club"));
            Initialize(new Suit("Heart"));
        }

        private void Initialize(Suit suit)
        {
            Cards.Add(new Card("Ace", suit, 1));

            for (int i = 2; i <= 10; i++)
            {
                Cards.Add(new Card(i.ToString(), suit, i));
            }

            Cards.Add(new Card("Jack", suit, 11));
            Cards.Add(new Card("Queen", suit, 12));
            Cards.Add(new Card("King", suit, 13));
        }
    }
}