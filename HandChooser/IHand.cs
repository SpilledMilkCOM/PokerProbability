using System.Collections.Generic;

namespace HandChooser
{
    public interface IHand
    {
        IEnumerable<Card> Cards { get; }

        bool IsFlush { get; }

        bool IsStraight { get; }

        void Add(Card card);

        void Clear();
    }
}