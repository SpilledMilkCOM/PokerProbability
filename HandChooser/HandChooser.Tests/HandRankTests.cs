using Microsoft.VisualStudio.TestTools.UnitTesting;
using SM.Cards;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HandChooser.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class HandRankTests
    {
        [TestMethod]
        public void HandRank_CompareTo_AreEqual()
        {
            var test = new HandRank(HandRankEnum.HighCard) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 5 };
            var test2 = new HandRank(HandRankEnum.HighCard) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 5 };

            test.SetHighCardValues(new List<int> { 9, 10, 7, 6, 4 });
            test2.SetHighCardValues(new List<int> { 9, 6, 10, 4, 7});

            Assert.AreEqual(0, test.CompareTo(test2));
            Assert.AreEqual(0, test2.CompareTo(test));
        }

        [TestMethod]
        public void HandRank_CompareTo_HighCardIsGreater()
        {
            var test = new HandRank(HandRankEnum.Flush) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 5 };
            var test2 = new HandRank(HandRankEnum.Flush) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 3 };

            Assert.AreEqual(1, test.CompareTo(test2));
            Assert.AreEqual(-1, test2.CompareTo(test));
        }

        [TestMethod]
        public void HandRank_CompareTo_HighCardsAreGreater()
        {
            var test = new HandRank(HandRankEnum.HighCard) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 5 };
            var test2 = new HandRank(HandRankEnum.HighCard) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 5 };

            test.SetHighCardValues(new List<int> { 9, 10, 7 });
            test2.SetHighCardValues(new List<int> { 9, 6, 10 });

            Assert.AreEqual(1, test.CompareTo(test2));
            Assert.AreEqual(-1, test2.CompareTo(test));
        }

        [TestMethod]
        public void HandRank_CompareTo_HighCardsAreGreater_DueToLongerList()
        {
            var test = new HandRank(HandRankEnum.HighCard) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 5 };
            var test2 = new HandRank(HandRankEnum.HighCard) { RankHighCardValue = 8, RankSecondHighCardValue = 7, HighCardValue = 5 };

            test.SetHighCardValues(new List<int> { 9, 10, 7 });
            test2.SetHighCardValues(new List<int> { 9, 6, 10, 7 });

            Assert.AreEqual(1, test.CompareTo(test2));
            Assert.AreEqual(-1, test2.CompareTo(test));
        }

        [TestMethod]
        public void HandRank_CompareTo_RankIsGreater()
        {
            var test = new HandRank(HandRankEnum.RoyalFlush);
            var test2 = new HandRank(HandRankEnum.StraighFlush);

            Assert.AreEqual(1, test.CompareTo(test2));
            Assert.AreEqual(-1, test2.CompareTo(test));
        }

        [TestMethod]
        public void HandRank_CompareTo_RankHighCardIsGreater()
        {
            var test = new HandRank(HandRankEnum.StraighFlush) { RankHighCardValue = 8 };
            var test2 = new HandRank(HandRankEnum.StraighFlush) { RankHighCardValue = 7 };

            Assert.AreEqual(1, test.CompareTo(test2));
            Assert.AreEqual(-1, test2.CompareTo(test));
        }

        [TestMethod]
        public void HandRank_CompareTo_RankSecondHighCardIsGreater()
        {
            var test = new HandRank(HandRankEnum.Flush) { RankHighCardValue = 8, RankSecondHighCardValue = 10 };
            var test2 = new HandRank(HandRankEnum.Flush) { RankHighCardValue = 8, RankSecondHighCardValue = 7 };

            Assert.AreEqual(1, test.CompareTo(test2));
            Assert.AreEqual(-1, test2.CompareTo(test));
        }
    }
}