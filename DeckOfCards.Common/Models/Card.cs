namespace DeckOfCards.Common.Models
{
    public class Card
    {
        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }
    }
}
