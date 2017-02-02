using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Cards.Poker
{
    public class TexasHoldemHand : IHand
    {
        private List<Card> _cards;

        public TexasHoldemHand()
        {
            _cards = new List<Card>();
        }

        public IEnumerable<Card> Cards { get { return _cards; } }

        public Card HighCard
        {
            get
            {
                return _cards.OrderByDescending(card => card.HighValue).FirstOrDefault();
            }
        }

        public bool IsFlush
        {
            get
            {
                var groups = _cards.GroupBy(item => item.Suit.Name);

                return groups.Count() == 1;
            }
        }

        public bool IsFourOfAKind
        {
            get
            {
                var groups = _cards.GroupBy(item => item.Name);

                // Four grouped up leaving three other distinct groups.

                return groups.Count() == 2;
            }
        }

        public bool IsFullHouse
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsPair
        {
            get
            {
                var groups = _cards.GroupBy(item => item.Name);

                // Two paired up in a group leaving three other distinct groups.

                return groups.Count() == 4;
            }
        }

        public bool IsStraight
        {
            get
            {
                var ordered = _cards.OrderBy(item => item.Value);
                var count = _cards.Count;

                return ordered.First().Value + (count - 1) == ordered.Last().Value ;
            }
        }

        public bool IsStraightFlush
        {
            get
            {
                return IsFlush && IsStraight;
            }
        }

        public bool IsThreeOfAKind
        {
            get
            {
                var groups = _cards.GroupBy(item => item.Name);

                // Three grouped up leaving two other distinct groups.

                return groups.Count() == 3;
            }
        }

        public bool IsTwoPair
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(Card card)
        {
            if (_cards.Any(item => item == card))
            {
                throw new Exception($"This hand already contains the card '{card}'.");
            }

            _cards.Add(card);

            if (_cards.Count > 5)
            {
                throw new Exception("Too many cards");
            }
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public Card Discard()
        {
            var result = _cards.FirstOrDefault();

            Remove(result);

            return result;
        }

        public Card Discard(Card card)
        {
            var result = _cards.FirstOrDefault(item => item == card);

            Remove(result);

            return result;
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