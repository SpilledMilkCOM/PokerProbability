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

        /// <summary>
        /// The number of cards in the hand (does NOT have to enumerate)
        /// </summary>
        public int Count
        {
            get
            {
                return _cards.Count;
            }
        }

        /// <summary>
        /// The highest value in the hand (includes any grouped cards)
        /// </summary>
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
                var count = groups.First().Count();

                // Four and one grouped up.

                return groups.Count() == 2 && (count == 1 || count == 4);
            }
        }

        public bool IsFullHouse
        {
            get
            {
                var groups = _cards.GroupBy(item => item.Name);
                var count = groups.First().Count();

                // Three and two grouped up.

                return groups.Count() == 2 && (count == 2 || count == 3);
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

        public bool IsRoyalFlush
        {
            get
            {
                return IsStraightFlush && HighCard?.HighValue == CardValues.ACE_HIGH;
            }
        }

        public bool IsStraight
        {
            get
            {
                var hasAce = HighCard?.Value == CardValues.ACE;
                var hasKing = _cards.Any(card => card.Value == CardValues.KING);
                var count = _cards.Count;

                IOrderedEnumerable<Card> ordered;

                if (hasAce && hasKing)
                {
                    ordered = _cards.OrderBy(item => item.HighValue);
                }
                else
                {
                    ordered = _cards.OrderBy(item => item.Value);
                }

                return ordered.First().Value + (count - 1) == ordered.Last().HighValue;
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
                var groups = _cards.GroupBy(item => item.Name);
                var count = groups.First().Count();

                // Two and Two and one grouped up.

                return groups.Count() == 3 && (count == 1 || count == 2);
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