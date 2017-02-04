namespace SM.Cards
{
    public interface ICard
    {
        string Abbreviation { get; set; }

        int HighValue { get; }

        int LowValue { get; }

        string Name { get; set; }

        ISuit Suit { get; set; }

        int Value { get; set; }
    }
}