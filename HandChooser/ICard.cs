namespace SM.Cards
{
    public interface ICard
    {
        string Abbreviation { get; set; }
        string Name { get; set; }
        Suit Suit { get; set; }
        int Value { get; set; }
    }
}