using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PracP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int NUM_CARDS = 52;
        const int DEFAULT_BID = 10;
        const int START_MONEY = 100;
        const int BLACKJACK = 21; //maximum points score in game

        Random rand = new Random();

        Deck deck = new Deck(); //create a new pack of cards before game start
        Hand player = new Hand();
        Hand dealer = new Hand();

        Card playerCard1;
        Card playerCard2;

        Card dealerCard1;
        Card dealerCard2;

        int moneyLeft = START_MONEY; //set initial money to $100

        private void buttonDealFirstCard_Click(object sender, EventArgs e)
        {
            
            //generate 4 new random cards
            player.Cards  = deck.Deal(2);
            dealer.Cards = deck.Deal(2);

            //display the first card to player and dealer
            textBoxPlayerCard1.Text = player.Cards[0].ToString();
            textBoxDealerCard1.Text = dealer.Cards[0].ToString();

            //clear the second card and totals
            textBoxPlayerCard2.Text = "";
            textBoxPlayerTotal.Text = "";
            textBoxDealerCard2.Text = "";
            textBoxDealerTotal.Text = "";
        }

        private void buttonDealSecondCard_Click(object sender, EventArgs e)
        {
            //display second two cards and total
            textBoxPlayerCard2.Text = player.Cards[1].ToString();
            textBoxDealerCard2.Text = dealer.Cards[1].ToString();

            Display();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoseGame()
        {
            MessageBox.Show("You lose!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add a third card to the hand
            player.Cards.Add(deck.GetCard());

            Display();
        }
        private void Display()
        {
            int playerTotal = player.Sum;
            int dealerTotal = dealer.Sum;

            textBoxPlayerTotal.Text = playerTotal.ToString();
            textBoxDealerTotal.Text = dealerTotal.ToString();

            if (playerTotal > BLACKJACK) //player bust loses, even if dealer bust
            {
                LoseGame();
            }
            else if (dealerTotal > BLACKJACK || playerTotal > dealerTotal)
            {
                MessageBox.Show("You win!");
            }
            else if (playerTotal == dealerTotal)
            {
                MessageBox.Show("You tie!");
            }
            else //player total less than dealer, and dealer did not bust.
            {
                LoseGame();
            }

        }
    }
}
