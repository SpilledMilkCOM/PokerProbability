using System.Collections.Generic;

namespace SM.Cards
{
    public interface IHand
    {
        IEnumerable<Card> Cards { get; }

        bool IsFlush { get; }

        bool IsFullHouse { get; }

        bool IsPair { get; }

        bool IsStraight { get; }

        bool IsThreeOfAKind { get; }

        bool IsTwoPair { get; }

        void Add(Card card);

        void Clear();
    }
}