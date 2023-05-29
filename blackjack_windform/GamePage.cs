using Blackjack;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blackjack_windform
{
    public partial class GamePage : Form
    {
        public static int bet_amount = 0;
        public GamePage()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void GamePage_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();


            bet_amount = 1;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 5;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 10;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 50;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 100;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Blackjack.Program.User user = new Blackjack.Program.User();

            bet_amount = 500;

            Blackjack.Program.Betting(user, bet_amount);

            MessageBox.Show(user.cash.ToString());
        }
    }
}
