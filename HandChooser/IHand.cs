using System.Collections.Generic;

namespace SM.Cards
{
    public interface IHand
    {
        IEnumerable<Card> Cards { get; }

        /// <summary>
        /// The number of cards in the hand (MAY have to enumerate).
        /// </summary>
        int Count { get; }

        Card HighCard { get; }

        bool IsFlush { get; }

        bool IsFourOfAKind { get; }

        bool IsFullHouse { get; }

        bool IsPair { get; }

        bool IsRoyalFlush { get; }

        bool IsStraight { get; }

        bool IsStraightFlush { get; }

        bool IsThreeOfAKind { get; }

        bool IsTwoPair { get; }

        void Add(Card card);

        void Clear();

        /// <summary>
        /// Remove any card from the hand.
        /// </summary>
        Card Discard();

        /// <summary>
        /// Remove specific card (by equality not by reference)
        /// </summary>
        /// <param name="card">The card (values) to remove.</param>
        Card Discard(Card card);
    }
}