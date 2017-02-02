namespace SM.Cards
{
    public class Card : ICard
    {
        public Card(Suit suit, int value)
            : this(value.ToString(), suit, value)
        {
            Suit = suit;
            Value = value;
        }

        public Card(string name, Suit suit, int value)
        {
            Name = name;
            Abbreviation = name.Substring(0, 1);
            Suit = suit;
            Value = value;
        }

        public string Abbreviation { get; set; }

        public string Name { get; set; }

        public Suit Suit { get; set; }

        public int Value { get; set; }
    }
}