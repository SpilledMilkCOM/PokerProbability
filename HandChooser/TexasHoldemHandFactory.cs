using System;
using System.Linq;

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

        public IHand ConstructFlush(Suit suit)
        {
            IHand result = ConstructCrappyHand();

            foreach(var card in result.Cards)
            {
                card.Suit = suit;
            }

            return result;
        }

        public IHand ConstructFourOfAKind(int value, int overValue)
        {
            IHand result = new TexasHoldemHand();

            result.Add(new Card(Spade, value));
            result.Add(new Card(Club, value));
            result.Add(new Card(Heart, value));
            result.Add(new Card(Diamond, value));
            result.Add(new Card(Club, overValue));

            return result;
        }

        public IHand ConstructFullHouse(int value, int overValue)
        {
            IHand result = new TexasHoldemHand();

            result.Add(new Card(Spade, value));
            result.Add(new Card(Club, value));
            result.Add(new Card(Heart, value));
            result.Add(new Card(Spade, overValue));
            result.Add(new Card(Club, overValue));

            return result;
        }

        public IHand ConstructRoyalFlush(Suit suit)
        {
            IHand result = new TexasHoldemHand();

            result.Add(new Card(suit, CardValues.TEN));
            result.Add(new Card(suit, CardValues.KING));
            result.Add(new Card(suit, CardValues.JACK));
            result.Add(new Card(suit, CardValues.ACE));
            result.Add(new Card(suit, CardValues.QUEEN));

            return result;
        }

        public IHand ConstructStraight(int highValue)
        {
            IHand result = new TexasHoldemHand();

            if (highValue < 5)
            {
                throw new Exception($"The '{nameof(highValue)}' of {highValue} should be 5 or greater.");
            }

            result.Add(new Card(SuitFactory.Club, highValue - 1));
            result.Add(new Card(SuitFactory.Diamond, highValue - 3));
            result.Add(new Card(SuitFactory.Heart, highValue));
            result.Add(new Card(SuitFactory.Spade, highValue - 2));
            result.Add(new Card(SuitFactory.Club, highValue - 4));

            return result;
        }

        public IHand ConstructStraightFlush(Suit suit, int highValue)
        {
            IHand result = new TexasHoldemHand();

            if (highValue < 5)
            {
                throw new Exception($"The '{nameof(highValue)}' of {highValue} should be 5 or greater.");
            }

            result.Add(new Card(suit, highValue - 1));
            result.Add(new Card(suit, highValue - 3));
            result.Add(new Card(suit, highValue));
            result.Add(new Card(suit, highValue - 2));
            result.Add(new Card(suit, highValue - 4));

            return result;
        }

        public IHand ConstructThreeOfAKind(int value)
        {
            IHand result = new TexasHoldemHand();

            result.Add(new Card(Spade, value));
            result.Add(new Card(Club, value));
            result.Add(new Card(Heart, value));
            result.Add(new Card(Spade, value < CardValues.TEN ? value + 1 : value - 1));
            result.Add(new Card(Club, value < CardValues.TEN ? value + 2 : value - 2));

            return result;
        }

        private Suit Club { get { return SuitFactory.Club; } }

        private Suit Diamond { get { return SuitFactory.Diamond; } }

        private Suit Heart { get { return SuitFactory.Heart; } }

        private Suit Spade { get { return SuitFactory.Spade; } }
    }
}
