using System;

namespace SM.Cards
{
    public class Card : ICard
    {
        public Card(ISuit suit, int value)
            : this(value.ToString(), suit, value)
        {
            Suit = suit;
            Value = value;
        }

        public Card(string name, ISuit suit, int value)
        {
            Name = (value == CardValues.ACE || value == CardValues.ACE_HIGH) ? CardNames.ACE : name;
            Abbreviation = Name.Substring(0, 1);
            Suit = suit;
            Value = value;
        }

        public string Abbreviation { get; set; }

        public string Name { get; set; }

        public ISuit Suit { get; set; }

        public int Value { get; set; }

        public int HighValue
        {
            get
            {
                return Name == CardNames.ACE ? CardValues.ACE_HIGH : Value;
            }
        }

        public int LowValue
        {
            get
            {
                return Name == CardNames.ACE ? CardValues.ACE : Value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Card && this == (Card)obj;
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }

        public static bool operator ==(Card first, Card second)
        {
            return first?.Name == second?.Name
                && first?.Suit.Name == second?.Suit.Name;
        }

        public static bool operator !=(Card first, Card second)
        {
            return !(first == second);
        }

        public override string ToString()
        {
            return $"{Name} of {Suit.Name}s";
        }
    }
}