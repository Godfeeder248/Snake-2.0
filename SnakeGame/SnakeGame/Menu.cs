using System;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            buttonEasy.Click += new EventHandler(this.EasyButton_Click);
            buttonHard.Click += new EventHandler(this.HardButton_Click);
        }

        void EasyButton_Click(Object sender,
                           EventArgs e)
        {
            
            GameWindow GameEasy = new GameWindow("EASY");
            GameEasy.Show();
           //this.Close();
        }
        void HardButton_Click(Object sender,
                           EventArgs e)
        {
            GameWindow GameHard = new GameWindow("HARD");
            GameHard.Show();
           // this.Close();
        }
    }
}
