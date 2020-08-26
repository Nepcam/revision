using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracP2
{
    class Deck
    {
        private const int NUM_CARDS = 52;
        public List<Card> Cards;
        public List<Card> Discards;
        private static Random rand;

        public Deck()
        {
            rand = new Random();
            Cards = new List<Card>();
            Discards = new List<Card>();
            //populate it
            for (int i = 0; i < NUM_CARDS; i++)
            {
                Card c = new Card(i);
                Cards.Add(c);
            }
        }

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> hand = new List<Card>();
            for (int i=0; i < numberOfCards; i++)
            {
                hand.Add(GetCard());
            }
            return hand;
        }

        public Card GetCard()
        {
            if (Cards.Count == 0)
            {
                //shuffle in new cards
                ReshuffleDeck();
            }
            int position = rand.Next(Cards.Count);
            Card c = Cards[position];
            Discards.Add(c);
            Cards.Remove(c);
            return c;
        }

        private void ReshuffleDeck()
        {
            //assume Cards is empty
            Cards = Discards; //'copy' all discards into cards
            Discards = new List<Card>(); //create a new empty discard list
            Shuffle();
        }

        public void Shuffle()
        {
            for(int i=0; i < Cards.Count; i++)
            {
                //with every card, swap with random position
                int position = rand.Next(Cards.Count);
                //swap cards
                Card c = Cards[i];
                Cards[i] = Cards[position];
                Cards[position] = c;
            }
        }
    }
}
