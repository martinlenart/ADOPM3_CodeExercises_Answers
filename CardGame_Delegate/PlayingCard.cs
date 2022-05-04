using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_Delegate
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need to compare not only Value but also Color if value is the same
		public int CompareTo(PlayingCard card1)
        {
			if (Value != card1.Value)
				return Value.CompareTo(card1.Value);
			else
				return Color.CompareTo(card1.Color);
        }
		#endregion

        #region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
			get
			{
				char c = Color switch
				{
					PlayingCardColor.Clubs => '\x2663',
					PlayingCardColor.Diamonds => '\x2666',
					PlayingCardColor.Hearts => '\x2665',
					_ => '\x2660', // Spades
				};
				return $"{c} {Value.ToString()}";
			}
		}

		public override string ToString() => $"{ShortDescription}";
        #endregion
    }
}
