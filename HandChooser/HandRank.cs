using System;
using System.Collections.Generic;

namespace SM.Cards
{
    public class HandRank : IComparable
    {
        private List<int> _cardValues;

        public HandRank()
            : this(HandRankEnum.Undefined) { }

        public HandRank(HandRankEnum rank)
        {
            Rank = rank;
        }

        public int HighCardValue { get; set; }

        /// <summary>
        /// Mostly for crappy hands comparing each card.
        /// </summary>
        public IEnumerable<int> HighCardValues { get; }

        public HandRankEnum Rank { get; set; }

        public int RankHighCardValue { get; set; }

        public int RankSecondHighCardValue { get; set; }

        public int CompareTo(object obj)
        {
            var rank = obj as HandRank;
            int result = 1;         // This object is greater than the object passed in

            if (rank != null)
            {
                if (Rank == rank.Rank)
                {
                    if (RankHighCardValue == rank.RankHighCardValue)
                    {
                        if (RankSecondHighCardValue == rank.RankSecondHighCardValue)
                        {
                            if (HighCardValue == rank.HighCardValue)
                            {
                                result = 0;
                            }
                            else if (HighCardValue < rank.HighCardValue)
                            {
                                result = -1;
                            }
                        }
                        else if (RankSecondHighCardValue < rank.RankSecondHighCardValue)
                        {
                            result = -1;
                        }
                    }
                    else if (RankHighCardValue < rank.RankHighCardValue)
                    {
                        result = -1;
                    }
                }
                else if (Rank < rank.Rank)
                {
                    result = -1;
                }
            }

            return result;
        }

        public void SetHighCardValues(List<int> cardValues)
        {
            // Make sure the list is sorted in descending order.
            _cardValues = cardValues;
            _cardValues.Sort();
            _cardValues.Reverse();
        }
    }
}