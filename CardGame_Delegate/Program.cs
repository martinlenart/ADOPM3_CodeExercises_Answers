using System;

namespace CardGame_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Notice on how I use IDeckOfCards and IPlayingCard
            IDeckOfCards myDeck = new DeckOfCards();
            Console.WriteLine($"Freshly created deck:");
            Console.WriteLine(myDeck);
            
            Console.WriteLine($"\nSorted deck:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            //Console.WriteLine($"\nShuffled deck:");
            //myDeck.Shuffle();
            //Console.WriteLine(myDeck);

            /*
            Console.WriteLine($"\nHandOfCards:");
            var myHand = new HandOfCards();

            myHand.Add(myDeck.DealOne());
            myHand.Add(myDeck.DealOne());
            myHand.Add(myDeck.DealOne());
            Console.WriteLine(myHand);
            Console.WriteLine(myHand.Highest);
            */

 
            Console.WriteLine("\nExtract all face cards");
            var extractedDeck1 = myDeck.Extract(card =>
            {
                return (card.Value == PlayingCardValue.Knight || card.Value == PlayingCardValue.Queen ||
                card.Value == PlayingCardValue.King || card.Value == PlayingCardValue.Ace);
            });
            Console.WriteLine(extractedDeck1);

            Console.WriteLine("\nOriginal deck after extraction");
            Console.WriteLine(myDeck);

            Console.WriteLine("\nExtract all cards with value 4");
            var extractedDeck2 = myDeck.Extract(card => card.Value == PlayingCardValue.Four);
            Console.WriteLine(extractedDeck2);
   
            Console.WriteLine("\nOriginal deck after extraction");
            Console.WriteLine(myDeck);
        }
    }
 }
