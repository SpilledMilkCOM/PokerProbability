using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SM.Cards;

namespace HandChooser.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Card_Construct_ValuesAreCorrect()
        {
            var test = ConstructTestObject(new Suit(SuitNames.HEART), 5);

            Assert.IsNotNull(test);
            Assert.AreEqual(5, test.Value);
            Assert.AreEqual(SuitNames.HEART, test.Suit.Name);
            Assert.AreEqual(CardNames.FIVE, test.Name);
            Assert.AreEqual(CardNames.FIVE, test.Abbreviation);
        }

        private ICard ConstructTestObject(Suit suit, int value)
        {
            return new Card(suit, value);
        }
    }
}