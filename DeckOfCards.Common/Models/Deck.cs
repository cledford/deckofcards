using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards.Common.Models
{
    public class Deck : IReadOnlyCollection<Card>
    {
        private SortedList<int,Card> _cards;

        public Deck()
        {
            BuildDeck();
        }

        public int Count => _cards.Count;

        public void Shuffle()
        {
            int n = _cards.Count;
            var rnd = new Random();

            // XXX: Using Fisher-Yates shuffle, as recommended on Stack Overflow:
            //  (see: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle)
            //  (see: https://stackoverflow.com/questions/273313/randomize-a-listt)
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        public void SortAscending()
        {
            var ordered = _cards.OrderBy(c => c.Value.Suit).ThenBy(v => v.Value.Value);

            int iterator = 0;
            foreach (var card in ordered)
            {
                _cards[iterator] = card.Value;
                iterator++;
            }
        }
       
        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal SortedList<int, Card> Cards => _cards;

        private void BuildDeck()
        {
            _cards = new SortedList<int, Card>(52);

            int iterator = 0;
            foreach (var suit in Enum.GetValues(typeof (CardSuit)))
            {
                foreach (var value in Enum.GetValues(typeof (CardValue)))
                {
                    _cards.Add(iterator, new Card((CardSuit) suit, (CardValue) value));
                    iterator++;
                }
            }              
        }
    }
}
