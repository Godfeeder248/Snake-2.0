using System;
using System.Diagnostics;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using ScoreLibrary;


namespace SnakeGame
{
    public partial class GameWindow : Form
    {
        Game game;

        public const int UP = 1;
        public const int DOWN = 2;
        public const int RIGHT = 3;
        public const int LEFT = 4;

        public const int EASY_SPEED = 2;
        public const int HARD_SPEED = 1;

        public static System.Windows.Forms.Timer myTimer;

        public GameWindow(String mode)
        {
           InitializeComponent(mode);

            /**********
             * Timer **
             * *******/

            myTimer = new System.Windows.Forms.Timer();

            /* Adds the event and the event handler for the method that will 
            process the timer event to the timer. */
            myTimer.Tick += new EventHandler(game_Paint);

            // Sets the timer interval to 2 seconds if mode is EASY, 1 second if mode is HARD.
            switch (mode)
            {
                case "EASY":
                    myTimer.Interval = (int)((float)(1000) * (EASY_SPEED));
                    break;
                case "HARD":
                    myTimer.Interval = (int)((float)(1000) * (HARD_SPEED));
                    break;
            }


            myTimer.Start();

        }


        // This is the method to run when the timer is raised.
        private void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            //Console.WriteLine(string.Format("TICK"));
            myTimer.Stop();

            /*********************************************
             *  Moves the snake in the direction it is in.
             *  ******************************************/
            
            game.Move_Snake();
            game.Refresh();
            ///// TO DO


            // Restarts the timer
            myTimer.Enabled = true;


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                    Debug.WriteLine("KeypressedR");
                    //MessageBox.Show("You pressed R arrow key");

                    //game.TickRefresh();
                    if(game.direction != LEFT)
                        game.direction = RIGHT;

                    return true;
                case Keys.Left:
                    Debug.WriteLine("KeypressedL");
                    //MessageBox.Show("You pressed Left arrow key");

                    //game.TickRefresh();

                    if (game.direction != RIGHT)
                        game.direction = LEFT;

                    return true;
                case Keys.Up:
                    Debug.WriteLine("KeypressedU");
                    //MessageBox.Show("You pressed U arrow key");

                    if (game.direction != DOWN)
                        game.direction = UP;

                    //game.TickRefresh();

                    return true;
                case Keys.Down:
                    Debug.WriteLine("KeypressedD");

                    if (game.direction != UP)
                        game.direction = DOWN;
                    //MessageBox.Show("You pressed D arrow key");

                    //game.TickRefresh();

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

        //private void panel1_Paint(object sender, PaintEventArgs e)
        private void game_Paint(object sender, EventArgs e)
        {
            myTimer.Stop();
            game.BackColor = Color.Black;
            foreach(Segment S in game.theSnake)
            {
                //S.Location = new System.Drawing.Point((S.get_posX() * 10), (S.get_posY() * 10));
                S.Image = Image.FromFile(@"..\..\Images\snakebody.png");
                System.Console.WriteLine("1");
                game.Controls.Add(S);
            }

            foreach (Segment S in game.Walls)
            {
                //S.Location = new System.Drawing.Point((S.get_posX() * 10), (S.get_posY() * 10));
                S.Image = Image.FromFile(@"..\..\Images\wall.png");
                game.Controls.Add(S);
                System.Console.WriteLine("2");
            }

            foreach (Segment S in game.Fruits)
            {
                //S.Location = new System.Drawing.Point((S.get_posX() * 10), (S.get_posY() * 10));
                S.Image = Image.FromFile(@"..\..\Images\food.png");
                System.Console.WriteLine("3");
                game.Controls.Add(S);
            }
            game.Move_Snake();
            ///// TO DO

            // Restarts the timer
            myTimer.Enabled = true;
        }
    }
}
