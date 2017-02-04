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
        public IEnumerable<int> HighCardValues { get { return _cardValues; } }

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
                                result = CompareHighCards(rank.HighCardValues);
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

        private int CompareHighCards(IEnumerable<int> toCompare)
        {
            var result = 1;
            var iter = toCompare.GetEnumerator();

            foreach(var cardValue in _cardValues)
            {
                if (iter.MoveNext())
                {
                    if (cardValue == iter.Current)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = (cardValue < iter.Current) ? - 1 : 1;
                        break;      // Found a difference so break out of the loop.
                    }
                }
                else
                {
                    // The list passed in has fewer items so more grouped up and therefore is a better hand.
                    result = -1;
                    break;
                }
            }

            if (iter.MoveNext())
            {
                // The list passed in MORE items so this hand is better.
                result = 1;
            }

            return result;
        }
    }
}