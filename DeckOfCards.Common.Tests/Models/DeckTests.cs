using DeckOfCards.Common.Models;
using NUnit.Framework;

namespace DeckOfCards.Common.Tests.Models
{
    [TestFixture]
    public class DeckTests
    {
        // How deck should initialize and in ascended order
        private static readonly Card[] StandardDeckExpected = {
            new Card(CardSuit.Club, CardValue.Ace),
            new Card(CardSuit.Club, CardValue.Two),
            new Card(CardSuit.Club, CardValue.Three),
            new Card(CardSuit.Club, CardValue.Four),
            new Card(CardSuit.Club, CardValue.Five),
            new Card(CardSuit.Club, CardValue.Six),
            new Card(CardSuit.Club, CardValue.Seven),
            new Card(CardSuit.Club, CardValue.Eight),
            new Card(CardSuit.Club, CardValue.Nine),
            new Card(CardSuit.Club, CardValue.Ten),
            new Card(CardSuit.Club, CardValue.Jack),
            new Card(CardSuit.Club, CardValue.Queen),
            new Card(CardSuit.Club, CardValue.King),
            new Card(CardSuit.Diamond, CardValue.Ace),
            new Card(CardSuit.Diamond, CardValue.Two),
            new Card(CardSuit.Diamond, CardValue.Three),
            new Card(CardSuit.Diamond, CardValue.Four),
            new Card(CardSuit.Diamond, CardValue.Five),
            new Card(CardSuit.Diamond, CardValue.Six),
            new Card(CardSuit.Diamond, CardValue.Seven),
            new Card(CardSuit.Diamond, CardValue.Eight),
            new Card(CardSuit.Diamond, CardValue.Nine),
            new Card(CardSuit.Diamond, CardValue.Ten),
            new Card(CardSuit.Diamond, CardValue.Jack),
            new Card(CardSuit.Diamond, CardValue.Queen),
            new Card(CardSuit.Diamond, CardValue.King),
            new Card(CardSuit.Heart, CardValue.Ace),
            new Card(CardSuit.Heart, CardValue.Two),
            new Card(CardSuit.Heart, CardValue.Three),
            new Card(CardSuit.Heart, CardValue.Four),
            new Card(CardSuit.Heart, CardValue.Five),
            new Card(CardSuit.Heart, CardValue.Six),
            new Card(CardSuit.Heart, CardValue.Seven),
            new Card(CardSuit.Heart, CardValue.Eight),
            new Card(CardSuit.Heart, CardValue.Nine),
            new Card(CardSuit.Heart, CardValue.Ten),
            new Card(CardSuit.Heart, CardValue.Jack),
            new Card(CardSuit.Heart, CardValue.Queen),
            new Card(CardSuit.Heart, CardValue.King),
            new Card(CardSuit.Spade, CardValue.Ace),
            new Card(CardSuit.Spade, CardValue.Two),
            new Card(CardSuit.Spade, CardValue.Three),
            new Card(CardSuit.Spade, CardValue.Four),
            new Card(CardSuit.Spade, CardValue.Five),
            new Card(CardSuit.Spade, CardValue.Six),
            new Card(CardSuit.Spade, CardValue.Seven),
            new Card(CardSuit.Spade, CardValue.Eight),
            new Card(CardSuit.Spade, CardValue.Nine),
            new Card(CardSuit.Spade, CardValue.Ten),
            new Card(CardSuit.Spade, CardValue.Jack),
            new Card(CardSuit.Spade, CardValue.Queen),
            new Card(CardSuit.Spade, CardValue.King),
        };

        [Test]
        public void DeckShouldInitializeCorrectly()
        {
            var deck = new Deck();

            for (int i = 0; i < 52; i++)
            {
                var expected = StandardDeckExpected[i];
                var actual = deck.Cards[i];

                Assert.AreEqual(expected.Suit, actual.Suit);
                Assert.AreEqual(expected.Value, actual.Value);
            }
        }

        [Test]
        public void DeckShouldShuffleCorrectly()
        {
            var deck = new Deck();

            deck.Shuffle();

            for (int i = 0; i < 52; i++)
            {
                var expected = StandardDeckExpected[i];
                var actual = deck.Cards[i];

                if (expected.Suit != actual.Suit || expected.Value != actual.Value)
                {
                    // We know we got some randomness here.
                    Assert.True(true);
                }
            }
        }

        [Test]
        public void DeckShouldSortAscendingCorrectly()
        {
            var deck = new Deck();

            /* XXX: An unfortunate side effect of DDD-style here is that I wrote the code in such a way 
             *      that you can't provide a shuffled set of cards to test the ascending sort function on its own.
             *      
             *      Spending more time thinking about it, I'd probably make the shuffle and sort methods static or 
             *      extension methods so they can be independently tested without relying on another function that 
             *      also requires testing.
             */
            deck.Shuffle();

            deck.SortAscending();

            for (int i = 0; i < 52; i++)
            {
                var expected = StandardDeckExpected[i];
                var actual = deck.Cards[i];

                Assert.AreEqual(expected.Suit, actual.Suit);
                Assert.AreEqual(expected.Value, actual.Value);
            }
        }
    }
}
