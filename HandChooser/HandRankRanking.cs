namespace SM.Cards
{
    public class HandRanking : IHandRanking
    {
        public HandRank Rank(IHand hand)
        {
            var result = new HandRank();

            if (hand.IsRoyalFlush)
            {
                result.Rank = HandRankEnum.RoyalFlush;
            }
            else if (hand.IsStraightFlush)
            {
                result.Rank = HandRankEnum.StraighFlush;
                result.RankHighCardValue = hand.HighCard.HighValue;
            }
            else if(hand.IsFourOfAKind)
            {
                result.Rank = HandRankEnum.FourOfAKind;
                // TODO: Group High Value
            }
            else if (hand.IsFullHouse)
            {
                result.Rank = HandRankEnum.FullHouse;
                // TODO: Group High Value
            }
            else if (hand.IsFlush)
            {
                result.Rank = HandRankEnum.Flush;
                result.RankHighCardValue = hand.HighCard.HighValue;
            }
            else if (hand.IsStraight)
            {
                result.Rank = HandRankEnum.Straight;
                result.RankHighCardValue = hand.HighCard.HighValue;
            }
            else if (hand.IsThreeOfAKind)
            {
                result.Rank = HandRankEnum.ThreeOfAKind;
                // TODO: Group High Value
            }
            else if (hand.IsTwoPair)
            {
                result.Rank = HandRankEnum.TwoPair;
                // TODO: Group High Value
            }
            else if (hand.IsPair)
            {
                result.Rank = HandRankEnum.OnePair;
                // TODO: Group High Value
            }
            else
            {
                result.Rank = HandRankEnum.HighCard;
                result.RankHighCardValue = hand.HighCard.HighValue;
            }

            result.HighCardValue = hand.HighCard.HighValue;

            return result;
        }
    }
}