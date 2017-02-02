using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandChooser.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Construct_52Cards()
        {
            var test = ConstructTestObject();

            Assert.AreEqual(52, test.Cards.Count);
        }

        private Deck ConstructTestObject()
        {
            return new Deck();
        }
    }
}