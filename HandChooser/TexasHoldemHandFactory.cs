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

        public IHand ConstructFullHouse(int value, int overValue)
        {
            var spade = new Suit(SuitNames.SPADE);
            var club = new Suit(SuitNames.CLUB);
            var heart = new Suit(SuitNames.HEART);

            IHand result = new TexasHoldemHand();

            result.Add(new Card(spade, value));
            result.Add(new Card(club, value));
            result.Add(new Card(heart, value));
            result.Add(new Card(spade, overValue));
            result.Add(new Card(club, overValue));

            return result;
        }
    }
}
