using Microsoft.VisualStudio.TestTools.UnitTesting;
using SM.Cards;
using SM.Cards.Poker;
using System.Diagnostics.CodeAnalysis;

namespace HandChooser.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class HandRankingTests
    {
        [TestMethod]
        public void HandRanking_Rank_Flush()
        {
            var test = ConstructTestObject();
            var hand = new TexasHoldemHandFactory().ConstructFlush(SuitFactory.Club);

            Assert.IsNotNull(test);

            var actual = test.Rank(hand);

            Assert.AreEqual(HandRankEnum.Flush, actual.Rank);
            Assert.AreEqual(7, actual.RankHighCardValue);
            Assert.AreEqual(0, actual.RankSecondHighCardValue);           // Not set.
            Assert.AreEqual(7, actual.HighCardValue);
        }

        [TestMethod]
        public void HandRanking_Rank_FullHouse()
        {
            var test = ConstructTestObject();
            var hand = new TexasHoldemHandFactory().ConstructFullHouse(5, 10);

            Assert.IsNotNull(test);

            var actual = test.Rank(hand);

            Assert.AreEqual(HandRankEnum.FullHouse, actual.Rank);
            Assert.AreEqual(5, actual.RankHighCardValue);
            Assert.AreEqual(10, actual.RankSecondHighCardValue);
            Assert.AreEqual(10, actual.HighCardValue);
        }

        [TestMethod]
        public void HandRanking_Rank_FourOfAKind()
        {
            var test = ConstructTestObject();
            var hand = new TexasHoldemHandFactory().ConstructFourOfAKind(5, 10);

            Assert.IsNotNull(test);

            var actual = test.Rank(hand);

            Assert.AreEqual(HandRankEnum.FourOfAKind, actual.Rank);
            Assert.AreEqual(5, actual.RankHighCardValue);
            Assert.AreEqual(10, actual.RankSecondHighCardValue);
            Assert.AreEqual(10, actual.HighCardValue);
        }

        [TestMethod]
        public void HandRanking_Rank_RoyalFlush()
        {
            var test = ConstructTestObject();
            var hand = new TexasHoldemHandFactory().ConstructRoyalFlush(SuitFactory.Club);

            Assert.IsNotNull(test);

            var actual = test.Rank(hand);

            Assert.AreEqual(HandRankEnum.RoyalFlush, actual.Rank);
            Assert.AreEqual(0, actual.RankHighCardValue);                 // Not set.
            Assert.AreEqual(0, actual.RankSecondHighCardValue);           // Not set.
            Assert.AreEqual(CardValues.ACE_HIGH, actual.HighCardValue);
        }

        [TestMethod]
        public void HandRanking_Rank_Straight()
        {
            var test = ConstructTestObject();
            var hand = new TexasHoldemHandFactory().ConstructStraight(8);

            Assert.IsNotNull(test);

            var actual = test.Rank(hand);

            Assert.AreEqual(HandRankEnum.Straight, actual.Rank);
            Assert.AreEqual(8, actual.RankHighCardValue);
            Assert.AreEqual(0, actual.RankSecondHighCardValue);           // Not set.
            Assert.AreEqual(8, actual.HighCardValue);
        }

        [TestMethod]
        public void HandRanking_Rank_StraightFlush()
        {
            var test = ConstructTestObject();
            var hand = new TexasHoldemHandFactory().ConstructStraightFlush(SuitFactory.Club, 8);

            Assert.IsNotNull(test);

            var actual = test.Rank(hand);

            Assert.AreEqual(HandRankEnum.StraighFlush, actual.Rank);
            Assert.AreEqual(8, actual.RankHighCardValue);
            Assert.AreEqual(0, actual.RankSecondHighCardValue);           // Not set.
            Assert.AreEqual(8, actual.HighCardValue);
        }

        [TestMethod]
        public void HandRanking_Rank_ThreeOfAKind()
        {
            var test = ConstructTestObject();
            var hand = new TexasHoldemHandFactory().ConstructThreeOfAKind(8);

            Assert.IsNotNull(test);

            var actual = test.Rank(hand);

            Assert.AreEqual(HandRankEnum.ThreeOfAKind, actual.Rank);
            Assert.AreEqual(8, actual.RankHighCardValue);
            Assert.AreEqual(10, actual.RankSecondHighCardValue);
            Assert.AreEqual(10, actual.HighCardValue);
        }

        private HandRanking ConstructTestObject()
        {
            return new HandRanking();
        }
    }
}