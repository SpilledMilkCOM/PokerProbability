namespace SM.Cards
{
    public class PileShuffler : IShuffler
    {
        public void Shuffle(IDeck deck)
        {
            var cards = deck.Cards;

            // TODO: Actually shuffle...

            deck.Reset(cards);
        }
    }
}