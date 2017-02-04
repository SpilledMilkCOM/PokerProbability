namespace SM.Cards
{
    public enum HandRankEnum
    {
        HighCard = 1,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraighFlush,
        RoyalFlush,             // Best hand is HIGHEST value.
        Undefined = -1
    }
}