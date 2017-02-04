using System.Collections.Generic;

namespace SM.Cards
{
    public interface IDeck
    {
        IEnumerable<Card> Cards { get; }

        Card Deal();

        Card Deal(string cardName);

        Card Deal(Card card);

        Card Deal(ISuit suit);

        void Reset();

        void Reset(IEnumerable<Card> cards);

        void Shuffle();

        void Shuffle(int count);
    }
}