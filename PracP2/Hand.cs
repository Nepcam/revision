using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracP2
{
    class Hand
    {
        public const int MAX_HAND_SIZE = 5;
        public string Name;
        public List<Card> Cards; //assume no more than 5 cards in a hand
        

        public Hand(string name = "unknown")
        {
            Cards = new List<Card>();
            Name = name;
          
        }

        public int Sum
        {
            get
            {
                int total = 0;
                foreach(Card c in Cards)
                { 
                    //must deal with aces better (laters)
                    total += c.Points;
                }
                return total;
            }
        }


    }
}
