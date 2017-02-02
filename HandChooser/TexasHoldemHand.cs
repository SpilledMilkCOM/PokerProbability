using System;
using System.Collections.Generic;
using System.Linq;

namespace HandChooser
{
    public class TexasHoldemHand : IHand
    {
        private List<Card> _cards;

        public TexasHoldemHand()
        {
            _cards = new List<Card>();
        }

        public IEnumerable<Card> Cards { get { return _cards; } }

        public bool IsFlush
        {
            get
            {
                var group = _cards.GroupBy(item => item.Suit.Name);

                return group.Count() == 1;
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

        public void Add(Card card)
        {
            _cards.Add(card);

            if (_cards.Count > 5)
            {
                throw new Exception("Too many cards!");
            }
        }

        public void Clear()
        {
            _cards.Clear();
        }
    }
}