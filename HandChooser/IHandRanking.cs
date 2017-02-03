namespace SM.Cards
{
    public interface IHandRanking
    {
        HandRank Rank(IHand hand);
    }
}