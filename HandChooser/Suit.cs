namespace SM.Cards
{
    public class Suit
    {
        public Suit(string name)
        {
            Name = name;
        }

        public string Abbreviation { get { return Name.Substring(0, 1); } }

        public string Name { get; set; }
    }
}