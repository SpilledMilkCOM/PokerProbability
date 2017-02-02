using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Cards
{
    public class Deck : IDeck
    {
        private List<Card> _cards;
        private IShuffler _shuffler;

        public Deck(IShuffler shuffler)
        {
            _shuffler = shuffler;

            _cards = new List<Card>();

            Initialize();
        }

        public IEnumerable<Card> Cards { get { return _cards; } }

        public Card Deal()
        {
            var result = _cards.FirstOrDefault();

            Remove(result);

            return result;
        }

        public Card Deal(Suit suit)
        {
            var result = _cards.FirstOrDefault(card => card.Suit == suit);

            Remove(result);

            return result;
        }

        public Card Deal(Card card)
        {
            throw new NotImplementedException();
        }

        public Card Deal(string cardName)
        {
            var result = _cards.FirstOrDefault(card => card.Name == cardName);

            Remove(result);

            return result;
        }

        public void Reset()
        {
            _cards.Clear();

            Initialize();
        }

        public void Reset(IEnumerable<Card> cards)
        {
            _cards.Clear();
            _cards.AddRange(cards);
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public void Shuffle(int count)
        {
            throw new NotImplementedException();
        }

        //----==== PRIVATE ====--------------------------------------------------------------------

        private void Initialize()
        {
            Initialize(new Suit(SuitNames.SPADE));
            Initialize(new Suit(SuitNames.DIAMOND));
            Initialize(new Suit(SuitNames.CLUB));
            Initialize(new Suit(SuitNames.HEART));
        }

        private void Initialize(Suit suit)
        {
            _cards.Add(new Card("Ace", suit, 1));

            for (int i = 2; i <= 10; i++)
            {
                _cards.Add(new Card(i.ToString(), suit, i));
            }

            _cards.Add(new Card("Jack", suit, 11));
            _cards.Add(new Card("Queen", suit, 12));
            _cards.Add(new Card("King", suit, 13));
        }

        private bool Remove(Card card)
        {
            bool removed = false;

            if (card != null)
            {
                removed = _cards.Remove(card);
            }

            return removed;
        }
    }
}