using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_Delegate
{
	/// <summary>
	/// Enum type representing a playing card color, also called suit
	/// </summary>
	public enum PlayingCardColor
	{
		Clubs = 0, Diamonds, Hearts, Spades         // Poker suit order, Spades highest
	}

	/// <summary>
	/// Enum type representing a playing card value
	/// </summary>
	public enum PlayingCardValue
	{
		Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
		Knight, Queen, King, Ace                // Poker Value order
	}

	interface IPlayingCard
    {
		/// <summary>
		/// The color or suit of the card
		/// </summary>
		public PlayingCardColor Color { get; init; }

		/// <summary>
		/// The value of the card
		/// </summary>
		public PlayingCardValue Value { get; init; }

		//Should be overriden and implemented to print out the in short notation
		public string ToString(); 
	}
}
