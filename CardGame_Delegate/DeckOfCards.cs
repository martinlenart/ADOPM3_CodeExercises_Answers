using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_Delegate
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx]
        {
            get
            {
                return cards[idx];
            }
        }
        #endregion

        public PlayingCard Highest
        {
            get
            {
                Sort();
                return cards[^1];
            }
        }

        public int Count => cards.Count();

        public PlayingCard DealOne()
        {
            PlayingCard card = cards[^1];
            cards.RemoveAt(cards.Count-1);

            return card;
        }

        #region ToString() related
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < cards.Count; i++)
            {
                sRet += $"{cards[i],-9}";
                if ((i + 1) % 13 == 0)
                    sRet += "\n";
            }
            return sRet;
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            if (cards.Count <= 0) return;

            var rnd = new Random();
            int nrOfShuffles = rnd.Next(100, 100000);
            for (int shuffle = 0; shuffle < nrOfShuffles; shuffle++)
            {
                //Swap to random cards with each other
                int loCard = rnd.Next(0, cards.Count);
                int hiCard = rnd.Next(0, cards.Count);

                (cards[loCard], cards[hiCard]) = (cards[hiCard], cards[loCard]);
            }
        }
        public void Sort() => cards.Sort();

        public IDeckOfCards Extract(Predicate<PlayingCard> match)
        {
            List<PlayingCard> extractedCards = cards.FindAll(match);
            cards.RemoveAll(match);

            return new DeckOfCards(extractedCards);
        }
        #endregion

        public DeckOfCards()
        {
            for (PlayingCardColor c = PlayingCardColor.Clubs; c <= PlayingCardColor.Spades; c++)
            {
                for (PlayingCardValue v = PlayingCardValue.Two; v <= PlayingCardValue.Ace; v++)
                {
                    cards.Add(new PlayingCard { Color = c, Value = v });
                }
            }
        }
        public DeckOfCards(List<PlayingCard> cards)
        {
            this.cards.AddRange(cards);
        }
    }
}
// Exercise:
// 1.  Create a Method that takes a delegate as a parameter and returns a new instance of DeckOfCards containing the cards
//     matching the crieras in the delegate. The cards should be removed from the original deck.
// 2.  Use lamda expression to create one deck with Face cards and one deck with value cards
