using System;
using System.Diagnostics;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using ScoreLibrary;
using System.Linq;

namespace SnakeGame
{
    public partial class GameWindow : Form
    {
        Game game;

        public const int UP = 1;
        public const int DOWN = 2;
        public const int RIGHT = 3;
        public const int LEFT = 4;

        public const int EASY_SPEED = 1;
        public const double HARD_SPEED = 0.5;

        Graphics g;

        Image bg = Image.FromFile(@"..\..\Images\bg.png");
        Image snakebody = Image.FromFile(@"..\..\Images\snakebody.png");
        Image snakeheadup = Image.FromFile(@"..\..\Images\snakeheadtoup.png");
        Image snakeheaddown = Image.FromFile(@"..\..\Images\snakeheadtobottom.png");
        Image snakeheadleft = Image.FromFile(@"..\..\Images\snakeheadtoleft.png");
        Image snakeheadright = Image.FromFile(@"..\..\Images\snakeheadtoright.png");

        Image wall = Image.FromFile(@"..\..\Images\wall.png");
        Image fruit = Image.FromFile(@"..\..\Images\food.png");


        public static System.Windows.Forms.Timer myTimer;

        public GameWindow(String mode)
        {
            InitializeComponent();


            this.game = new Game(mode);

            /**********
             * Timer **
             * *******/

            myTimer = new System.Windows.Forms.Timer();

            /* Adds the event and the event handler for the method that will 
            process the timer event to the timer. */
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 2 seconds if mode is EASY, 1 second if mode is HARD.
            switch (mode)
            {
                case "EASY":
                    myTimer.Interval = (int)((float)(100) * (EASY_SPEED));
                    break;
                case "HARD":
                    myTimer.Interval = (int)((float)(100) * (HARD_SPEED));
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
            if (game.game_over == false)
                game.update_snake();
            else
                myTimer.Stop();
            //game.Move_Snake();
            //game.Refresh();
            panel1.Invalidate();
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
                    if (game.direction != LEFT)
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
            myTimer.Stop();
            ScoreForm score = new ScoreForm();
            //  Score.SaveData(ScoreForm.SCORE_FILENAME);
            Score.LoadData(ScoreForm.SCORE_FILENAME);
            score.ViewUpdate();

            score.Show();
        }

        private void buttonPause_Click_1(object sender, EventArgs e)
        {
            myTimer.Stop();
            Boolean isPaused = true;
            while (isPaused)
            {
                string message = "Game is paused. Start again ?";
                string caption = "Game Paused";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    isPaused = false;
                }

            }

            // Restarts the timer
            myTimer.Enabled = true;

        }

        //private void panel1_Paint(object sender, PaintEventArgs e)
        private void game_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.Black;
            lblScore.Text = "Score : " + game.score.ToString();
            g = e.Graphics;
            // g.Clear(Color.Black);

            //game.theSnake[0];

            switch (game.direction)
            {
                case UP:
                    g.DrawImage(snakeheadup, (game.theSnake[0].get_posY() * 20), (game.theSnake[0].get_posX() * 20));
                    break;
                case DOWN:
                    g.DrawImage(snakeheaddown, (game.theSnake[0].get_posY() * 20), (game.theSnake[0].get_posX() * 20));
                    break;
                case LEFT:
                    g.DrawImage(snakeheadleft, (game.theSnake[0].get_posY() * 20), (game.theSnake[0].get_posX() * 20));
                    break;
                case RIGHT:
                    g.DrawImage(snakeheadright, (game.theSnake[0].get_posY() * 20), (game.theSnake[0].get_posX() * 20));
                    break;
            }

            foreach (Segment S in (game.theSnake).Skip(1))
            {
                //S.Location = new System.Drawing.Point((S.get_posX() * 10), (S.get_posY() * 10));
                //S.Image = Image.FromFile(@"..\..\Images\snakebody.png");
                //game.Controls.Add(S);
                g.DrawImage(snakebody, (S.get_posY() * 20), (S.get_posX() * 20));
            }

            foreach (Segment S in game.Walls)
            {
                //S.Location = new System.Drawing.Point((S.get_posX() * 10), (S.get_posY() * 10));
                //S.Image = Image.FromFile(@"..\..\Images\wall.png");
                //game.Controls.Add(S);
                g.DrawImage(wall, (S.get_posY() * 20), (S.get_posX() * 20));
            }

            foreach (Segment S in game.Fruits)
            {
                //S.Location = new System.Drawing.Point((S.get_posX() * 10), (S.get_posY() * 10));
                // S.Image = Image.FromFile(@"..\..\Images\food.png");
                //game.Controls.Add(S);
                g.DrawImage(fruit, (S.get_posY() * 20), (S.get_posX() * 20));
            }

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (game.grid[i, j] == 0)
                    {
                        g.DrawImage(bg, (i * 20), (j * 20));
                    }
                }
            }
        }
    }
}
