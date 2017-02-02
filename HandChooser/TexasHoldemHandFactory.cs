namespace SM.Cards.Poker
{
    public class TexasHoldemHandFactory
    {
        public IHand ConstructCrappyHand()
        {
            var suit = new Suit(SuitNames.SPADE);
            IHand result = new TexasHoldemHand();

            result.Add(new Card(suit, 2));
            result.Add(new Card(suit, 3));
            result.Add(new Card(new Suit(SuitNames.HEART), 4));
            result.Add(new Card(suit, 5));
            result.Add(new Card(suit, 7));

            return result;
        }
    }
}
