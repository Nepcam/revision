using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracP2
{
    /// <summary>
    /// Holds a single card, with both a suit and a value
    /// </summary>
    class Card
    {
        private string _suit; //the card suit
        private int _number; //the number of the card, 1 = Ace through to 13 = King

        /// <summary>
        /// Holds a single card, with both a suit and a value
        /// the first 13 values are Clubs, the next 13 are Spades, then Diamonds, then Hearts.
        /// Within each suit the cards order from 0 = Ace to 13 = King.
        /// </summary>
        /// <param name="cardNumber">A value from 0 to 51 which determines the card suit and value</param>
        public Card(int cardNumber)
        {
            _number = cardNumber % 13 + 1;
            int suit = cardNumber / 13;
            if (suit == 0)
                _suit = "Clubs";
            else if (suit == 1)
                _suit = "Spades";
            else if (suit == 2)
                _suit = "Diamonds";
            else
                _suit = "Hearts";
        }

        /// <summary>
        /// Displays the card value and suit, i.e. "Ace of Hearts" or "2 of Spades"
        /// </summary>
        /// <returns>the name of the card</returns>
        public override string ToString()
        {
            string cardName = _number.ToString(); 
            cardName += " of " + _suit;
            return cardName;
        }

        /// <summary>
        /// The number of points the card is worth in Blackjack.
        /// An ace is worth 11. A picture card (King, Queen, Jack) is worth 10.
        /// All other cards are worth face value.
        /// </summary>
        public int Points
        {
            get
            {
               return _number;
            }
        }
    }
}
