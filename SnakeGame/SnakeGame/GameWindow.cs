using System;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class GameWindow : Form
    {
        public GameWindow(String mode)
        {
            InitializeComponent();

            Game game = new Game(mode);
        }
    }
}
