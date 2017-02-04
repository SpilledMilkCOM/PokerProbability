using System.Linq;

namespace SM.Cards
{
    public class HandRanking : IHandRanking
    {
        public HandRank Rank(IHand hand)
        {
            var result = new HandRank();

            // TODO: Could set up visitors on the hand to determine rank (versus all this IF stuff)

            result.HighCardValue = hand.HighCard.HighValue;

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

                TwoGroupRank(hand, result);
            }
            else if (hand.IsFullHouse)
            {
                result.Rank = HandRankEnum.FullHouse;

                TwoGroupRank(hand, result);
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

            return result;
        }

        private void TwoGroupRank(IHand hand, HandRank rank)
        {
                var group = (from card in hand.Cards
                             group card by card.Name into grouped
                             orderby grouped.Count()
                             select grouped);

            // Should only be two groups.

            rank.RankHighCardValue = group.First().First().HighValue;
            rank.RankSecondHighCardValue = group.Last().First().HighValue;
        }
    }
}