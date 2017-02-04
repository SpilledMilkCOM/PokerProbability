namespace SM.Cards
{
    public class Suit : ISuit
    {
        public Suit(string name)
        {
            Name = name;
        }

        public string Abbreviation { get { return Name.Substring(0, 1); } }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Suit && this == (Suit)obj;
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }

        public static bool operator ==(Suit first, Suit second)
        {
            return first.Name == second.Name;
        }

        public static bool operator !=(Suit first, Suit second)
        {
            return !(first == second);
        }
    }
}