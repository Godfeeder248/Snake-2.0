using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // this.Close();

        }

        private void buttonHard_Click(object sender, EventArgs e)
        {
            GameWindow GameHard = new GameWindow("HARD");
            GameHard.Show();
           // this.Close();
        }
    }
    
}
