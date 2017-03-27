using System;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;
using ScoreLibrary;


namespace SnakeGame
{
    public partial class GameWindow : Form
    {
        Game game;

        public GameWindow(String mode)
        {
            InitializeComponent();

            game = new Game(mode);


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char key;
            switch (keyData)
            {
                case Keys.Right:
                    key = 'R';
                    Debug.WriteLine("KeypressedR");
                    //MessageBox.Show("You pressed R arrow key");

                    game.TickRefresh();

                    return true;
                case Keys.Left:
                    key = 'L';
                    Debug.WriteLine("KeypressedL");
                    //MessageBox.Show("You pressed Left arrow key");

                    game.TickRefresh();

                    return true;
                case Keys.Up:
                    key = 'U';
                    Debug.WriteLine("KeypressedU");
                    //MessageBox.Show("You pressed U arrow key");

                    game.TickRefresh();

                    return true;
                case Keys.Down:
                    key = 'D';
                    Debug.WriteLine("KeypressedD");
                    //MessageBox.Show("You pressed D arrow key");

                    game.TickRefresh();

                    // DO WHAT YOU NEED
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void buttonScores_Click(object sender, EventArgs e)
        {
            ScoreForm score = new ScoreForm();
          //  Score.SaveData(ScoreForm.SCORE_FILENAME);
            Score.LoadData(ScoreForm.SCORE_FILENAME);
            score.ViewUpdate();

            score.Show();
        }

        private void buttonPause_Click_1(object sender, EventArgs e)
        {
            ScoreEntryForm SEF = new ScoreEntryForm();
            SEF.Show();
        }

    }
}
