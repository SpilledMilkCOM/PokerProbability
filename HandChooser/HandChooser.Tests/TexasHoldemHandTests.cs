using Microsoft.VisualStudio.TestTools.UnitTesting;
using SM.Cards;
using SM.Cards.Poker;
using System.Diagnostics.CodeAnalysis;

namespace HandChooser.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class TexasHoldemHandTests
    {
        [TestMethod]
        public void TexasHoldemHand_Clear_DiscardsAllCards()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();

            Assert.AreEqual(5, test.Count);

            test.Clear();

            Assert.AreEqual(0, test.Count);
        }

        [TestMethod]
        public void TexasHoldemHand_Discard()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();
            var initialCount = test.Count;

            test.Discard();
            test.Discard();

            Assert.AreEqual(initialCount - 2, test.Count);
        }

        [TestMethod]
        public void TexasHoldemHand_HighCard()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();
            var expected = new Card(new Suit(SuitNames.SPADE), 7);

            Assert.AreEqual(expected, test.HighCard);
        }

        [TestMethod]
        public void TexasHoldemHand_HighCardIsAce()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();
            var expected = new Card(new Suit(SuitNames.SPADE), CardValues.ACE);

            test.Discard();
            test.Add(expected);

            Assert.AreEqual(expected, test.HighCard);
        }

        [TestMethod]
        public void TexasHoldemHand_IsFlush()
        {
            var test = ConstructTestObject();
            var suit = new Suit(SuitNames.SPADE);

            test.Add(new Card(CardNames.ACE, suit, CardValues.ACE));
            test.Add(new Card("2", suit, 2));
            test.Add(new Card("King", suit, 13));
            test.Add(new Card("5", suit, 5));
            test.Add(new Card("8", suit, 8));

            Assert.IsTrue(test.IsFlush);
        }

        [TestMethod]
        public void TexasHoldemHand_IsFourOfAKind()
        {
            var test = ConstructTestObject();
            var suit = new Suit(SuitNames.SPADE);

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(new Suit(SuitNames.DIAMOND), 2));
            test.Add(new Card(new Suit(SuitNames.HEART), 2));
            test.Add(new Card(new Suit(SuitNames.CLUB), 2));

            Assert.IsTrue(test.IsFourOfAKind);
        }

        [TestMethod]
        public void TexasHoldemHand_IsFullHouse()
        {
            var test = ConstructTestObject();

            test.Add(new Card(Club, 3));
            test.Add(new Card(Club, 6));
            test.Add(new Card(Diamond, 3));
            test.Add(new Card(Diamond, 6));
            test.Add(new Card(Heart, 3));

            Assert.IsTrue(test.IsFullHouse);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotFlush()
        {
            var test = ConstructTestObject();
            var suit = new Suit(SuitNames.SPADE);

            test.Add(new Card("Ace", suit, 1));
            test.Add(new Card(suit, 2));
            test.Add(new Card("King", new Suit("Club"), 13));
            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 8));

            Assert.IsFalse(test.IsFlush);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotFourOfAKind()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();

            Assert.IsFalse(test.IsFourOfAKind);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotFullHouse()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();

            Assert.IsFalse(test.IsFullHouse);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotPair()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();

            Assert.IsFalse(test.IsPair);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotStraight()
        {
            var test = ConstructTestObject();
            var suit = new Suit(SuitNames.SPADE);

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(suit, 7));
            test.Add(new Card(suit, 3));
            test.Add(new Card(suit, 6));

            Assert.IsFalse(test.IsStraight);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotStraightFlush()
        {
            var test = ConstructTestObject();
            var suit = new Suit(SuitNames.SPADE);

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(new Suit(SuitNames.HEART), 4));
            test.Add(new Card(suit, 3));
            test.Add(new Card(suit, 6));

            Assert.IsFalse(test.IsStraightFlush);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotThreeOfAKind()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();

            Assert.IsFalse(test.IsThreeOfAKind);
        }

        [TestMethod]
        public void TexasHoldemHand_IsNotTwoPair()
        {
            var test = new TexasHoldemHandFactory().ConstructCrappyHand();

            Assert.IsFalse(test.IsTwoPair);
        }

        [TestMethod]
        public void TexasHoldemHand_IsPair()
        {
            var test = ConstructTestObject();
            var suit = new Suit(SuitNames.SPADE);

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(suit, 4));
            test.Add(new Card(new Suit(SuitNames.HEART), 2));
            test.Add(new Card(suit, 6));

            Assert.IsTrue(test.IsPair);
        }

        [TestMethod]
        public void TexasHoldemHand_IsRoyalFlush()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card(suit, CardValues.TEN));
            test.Add(new Card(suit, CardValues.JACK));
            test.Add(new Card(suit, CardValues.QUEEN));
            test.Add(new Card(suit, CardValues.ACE));
            test.Add(new Card(suit, CardValues.KING));

            Assert.IsTrue(test.IsRoyalFlush);
        }

        [TestMethod]
        public void TexasHoldemHand_IsStraight()
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
        public void TexasHoldemHand_IsStraightHigh()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card(suit, CardValues.TEN));
            test.Add(new Card(suit, CardValues.JACK));
            test.Add(new Card(suit, CardValues.QUEEN));
            test.Add(new Card(suit, CardValues.ACE));
            test.Add(new Card(suit, CardValues.KING));

            Assert.IsTrue(test.IsStraight);
        }

        [TestMethod]
        public void TexasHoldemHand_IsStraightLow()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(suit, 4));
            test.Add(new Card(suit, 3));
            test.Add(new Card(suit, CardValues.ACE));

            Assert.IsTrue(test.IsStraight);
        }

        [TestMethod]
        public void TexasHoldemHand_IsStraightFlush()
        {
            var test = ConstructTestObject();
            var suit = new Suit("Spade");

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(suit, 4));
            test.Add(new Card(suit, 3));
            test.Add(new Card(suit, 6));

            Assert.IsTrue(test.IsStraightFlush);
        }

        [TestMethod]
        public void TexasHoldemHand_IsThreeOfAKind()
        {
            var test = ConstructTestObject();
            var suit = new Suit(SuitNames.SPADE);

            test.Add(new Card(suit, 5));
            test.Add(new Card(suit, 2));
            test.Add(new Card(suit, 4));
            test.Add(new Card(new Suit(SuitNames.HEART), 2));
            test.Add(new Card(new Suit(SuitNames.CLUB), 2));

            Assert.IsTrue(test.IsThreeOfAKind);
        }

        [TestMethod]
        public void TexasHoldemHand_IsTwoPair()
        {
            var test = ConstructTestObject();

            test.Add(new Card(Club, 3));
            test.Add(new Card(Club, 6));
            test.Add(new Card(Diamond, 3));
            test.Add(new Card(Diamond, 6));
            test.Add(new Card(Heart, 5));

            Assert.IsTrue(test.IsTwoPair);
        }

        private IHand ConstructTestObject()
        {
            return new TexasHoldemHand();
        }

        private Suit Club { get { return new Suit(SuitNames.CLUB); } }

        private Suit Diamond { get { return new Suit(SuitNames.DIAMOND); } }

        private Suit Heart { get { return new Suit(SuitNames.HEART); } }

        private Suit Spade { get { return new Suit(SuitNames.SPADE); } }
    }
}