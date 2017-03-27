using System;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonEasy_Click(object sender, EventArgs e)
        {
            GameWindow GameEasy = new GameWindow("EASY");
            GameEasy.Show();
            //this.Close();
        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            GameWindow GameHard = new GameWindow("HARD");
            GameHard.Show();
            // this.Close();
        }
    }
    
}
