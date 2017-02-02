using Microsoft.VisualStudio.TestTools.UnitTesting;
using SM.Cards;
using System.Diagnostics.CodeAnalysis;

namespace HandChooser.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Card_Construct_Ace()
        {
            var test = ConstructTestObject(new Suit(SuitNames.SPADE), CardValues.ACE);

            Assert.IsNotNull(test);
            Assert.AreEqual(CardValues.ACE, test.Value);
            Assert.AreEqual(SuitNames.SPADE, test.Suit.Name);
            Assert.AreEqual(CardNames.ACE, test.Name);
            Assert.AreEqual(CardValues.ACE_HIGH, test.HighValue);
            Assert.AreEqual(CardValues.ACE, test.LowValue);
        }

        [TestMethod]
        public void Card_Construct_AceHigh()
        {
            var test = ConstructTestObject(new Suit(SuitNames.SPADE), CardValues.ACE_HIGH);

            Assert.IsNotNull(test);
            Assert.AreEqual(CardValues.ACE_HIGH, test.Value);
            Assert.AreEqual(SuitNames.SPADE, test.Suit.Name);
            Assert.AreEqual(CardNames.ACE, test.Name);
            Assert.AreEqual(CardValues.ACE_HIGH, test.HighValue);
            Assert.AreEqual(CardValues.ACE, test.LowValue);
        }

        [TestMethod]
        public void Card_Construct_ValuesAreCorrect()
        {
            var test = ConstructTestObject();

            Assert.IsNotNull(test);
            Assert.AreEqual(5, test.Value);
            Assert.AreEqual(SuitNames.HEART, test.Suit.Name);
            Assert.AreEqual(CardNames.FIVE, test.Name);
            Assert.AreEqual(CardNames.FIVE, test.Abbreviation);
        }

        [TestMethod]
        public void Card_OperatorEquals()
        {
            Card test1 = null;
            Card test2 = null;

            Assert.IsTrue(test1 == test2);
        }

        [TestMethod]
        public void Card_OperatorNotEquals()
        {
            ICard test1 = ConstructTestObject();
            Card test2 = null;

            Assert.IsTrue(test1 != test2);
        }

        private ICard ConstructTestObject()
        {
            return new Card(new Suit(SuitNames.HEART), 5);
        }

        private ICard ConstructTestObject(Suit suit, int value)
        {
            return new Card(suit, value);
        }
    }
}