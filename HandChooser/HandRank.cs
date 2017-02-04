namespace SM.Cards
{
    public class HandRank
    {
        public HandRank()
        {
            Rank = HandRankEnum.Undefined;
        }

        public HandRankEnum Rank { get; set; }

        public int HighCardValue { get; set; }

        public int RankHighCardValue { get; set; }

        public int RankSecondHighCardValue { get; set; }
    }
}