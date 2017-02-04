using Microsoft.VisualStudio.TestTools.UnitTesting;
using SM.Cards;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HandChooser.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Construct_52Cards()
        {
            var test = ConstructTestObject();

            Assert.AreEqual(52, test.Cards.Count());
        }

        [TestMethod]
        public void Deck_Deal_CardName()
        {
            var test = ConstructTestObject();

            var card = test.Deal(CardNames.FOUR);

            Assert.IsNotNull(card);
            Assert.AreEqual(CardNames.FOUR, card.Name);
        }

        [TestMethod]
        public void Deck_Deal_CardSuit()
        {
            var test = ConstructTestObject();

            var card = test.Deal(new Suit(SuitNames.HEART));

            Assert.IsNotNull(card);
            Assert.AreEqual(SuitNames.HEART, card.Suit.Name);
        }

        [TestMethod]
        public void Deck_Reset()
        {
            var test = ConstructTestObject();
            var initialCount = test.Cards.Count();

            test.Deal();
            test.Deal();
            test.Deal();

            Assert.IsTrue(initialCount > test.Cards.Count());

            test.Reset();

            Assert.AreEqual(initialCount, test.Cards.Count());
        }

        [TestMethod]
        public void Deck_Reset_WithNewCards()
        {
            var test = ConstructTestObject();
            var deck2 = ConstructTestObject();

            deck2.Deal();
            deck2.Deal();
            deck2.Deal();

            test.Reset(deck2.Cards);

            Assert.AreEqual(deck2.Cards.Count(), test.Cards.Count());
        }

        private IDeck ConstructTestObject()
        {
            return new Deck(new PileShuffler());
        }
    }
}