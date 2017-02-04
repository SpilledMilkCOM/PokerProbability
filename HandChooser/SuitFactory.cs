namespace SM.Cards
{
    public static class SuitFactory
    {
        public static Suit Club { get { return new Suit(SuitNames.CLUB); } }

        public static Suit Diamond { get { return new Suit(SuitNames.DIAMOND); } }

        public static Suit Heart { get { return new Suit(SuitNames.HEART); } }

        public static Suit Spade { get { return new Suit(SuitNames.SPADE); } }
    }
}