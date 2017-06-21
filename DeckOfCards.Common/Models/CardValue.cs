namespace DeckOfCards.Common.Models
{
    /// <summary>
    ///  XXX: Ace at 0 for sorting purposes 
    ///     (see: https://en.wikipedia.org/wiki/Standard_52-card_deck)
    /// </summary>
    public enum CardValue
    {
        Ace = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
}