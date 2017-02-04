namespace SM.Cards
{
    public static class SuitFactory
    {
        public static ISuit Club { get { return new Suit(SuitNames.CLUB); } }

        public static ISuit Diamond { get { return new Suit(SuitNames.DIAMOND); } }

        public static ISuit Heart { get { return new Suit(SuitNames.HEART); } }

        public static ISuit Spade { get { return new Suit(SuitNames.SPADE); } }
    }
}