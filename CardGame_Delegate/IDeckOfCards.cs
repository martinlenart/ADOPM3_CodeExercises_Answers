using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_Delegate
{
    interface IDeckOfCards
    {
         /// <summary>
         /// The card at a particular position in the deck.
         /// </summary>
         /// <param name="idx">0 based position in the deck</param>
         /// <returns>The card at [idx] position</returns>
        public PlayingCard this[int idx] { get; }
        
        //Should be overriden and implemented to print out the complete deck in short card notation
        public string ToString();
        PlayingCard DealOne();

        /// <summary>
        /// Extracts all the cards matching the filter criteria into a new DeckOfCards
        /// </summary>
        /// <param name="filter">Delegate returning true for all the cards that should be extracted</param>
        /// <returns>DeckOfCards</returns>
        public IDeckOfCards Extract(Predicate<PlayingCard> match);

        /// <summary>
        /// Shuffles the deck of cards
        /// </summary>
        public void Shuffle();
        
        /// <summary>
        /// Sort the deck of cards using List<T> Sort()>
        /// </summary>
        public void Sort();
    }
}
