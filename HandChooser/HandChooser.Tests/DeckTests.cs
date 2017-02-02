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
        public void Deal_CardValue()
        {
            var test = ConstructTestObject();

            var card = test.Deal();

            Assert.AreEqual(52, test.Cards.Count());
        }

        private IDeck ConstructTestObject()
        {
            return new Deck(new PileShuffler());
        }
    }
}