using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using SM.Cards;
using SM.Cards.Poker;

namespace HandChooser.Tests
{
    [TestClass]
    public class TexasHoldemHandTests
    {
        [TestMethod]
        public void IsFlush()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card("Ace", suit, 1));
            test.Add(new Card("2", suit, 2));
            test.Add(new Card("King", suit, 13));
            test.Add(new Card("5", suit, 5));
            test.Add(new Card("8", suit, 8));

            Assert.IsTrue(test.IsFlush);
        }

        [TestMethod]
        public void IsNotFlush()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card("Ace", suit, 1));
            test.Add(new Card(suit, 2));
            test.Add(new Card("King", new Suit("Club"), 13));
            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 8));

            Assert.IsFalse(test.IsFlush);
        }

        [TestMethod]
        public void IsStraight()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(suit, 4));
            test.Add(new Card(suit, 3));
            test.Add(new Card(suit, 6));

            Assert.IsTrue(test.IsStraight);
        }

        [TestMethod]
        public void IsNotStraight()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(suit, 7));
            test.Add(new Card(suit, 3));
            test.Add(new Card(suit, 6));

            Assert.IsFalse(test.IsStraight);
        }

        private IHand ConstructTestObject()
        {
            return new TexasHoldemHand();
        }
    }
}