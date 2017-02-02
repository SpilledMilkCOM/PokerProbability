namespace SM.Cards
{
    public interface ICard
    {
        string Abbreviation { get; set; }

        int HighValue { get; }

        int LowValue { get; }

        string Name { get; set; }

        Suit Suit { get; set; }

        int Value { get; set; }
    }
}