using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SM.Cards;

namespace HandChooser.Tests
{
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
        public void Deck_Deal_CardSuite()
        {
            var test = ConstructTestObject();

            var card = test.Deal(new Suit(SuitNames.HEART));

            Assert.IsNotNull(card);
            Assert.AreEqual(SuitNames.HEART, card.Suit.Name);
        }

        private IDeck ConstructTestObject()
        {
            return new Deck(new PileShuffler());
        }
    }
}