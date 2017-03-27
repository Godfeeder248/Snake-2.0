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
            myTimer.Stop();

            /*********************************************
             *  Moves the snake in the direction it is in.
             *  ******************************************/
            if (game.game_over == false)
                game.update_snake();
            else
                myTimer.Stop();
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
                    if (game.direction != LEFT)
                        game.direction = RIGHT;
                    return true;
                case Keys.Left:
                    Debug.WriteLine("KeypressedL");
                    if (game.direction != RIGHT)
                        game.direction = LEFT;
                    return true;
                case Keys.Up:
                    Debug.WriteLine("KeypressedU");

                    if (game.direction != DOWN)
                        game.direction = UP;
                    return true;
                case Keys.Down:
                    Debug.WriteLine("KeypressedD");

                    if (game.direction != UP)
                        game.direction = DOWN;
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void buttonScores_Click(object sender, EventArgs e)
        {
            ScoreForm score = new ScoreForm();
            Score.LoadData(ScoreForm.SCORE_FILENAME);
            score.ViewUpdate();

            score.Show();
        }
        private void buttonNew_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("New Game");
            this.game.eat_fruit();
            this.game.Walls.Clear();
            this.game.theSnake.Clear();
            this.game.Grow_Snake(10, 10);
            this.game.score = 0;
            this.game.build_grid();
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
        
        private void game_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            lblScore.Text = "Score : " + game.score.ToString();

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
                g.DrawImage(snakebody, (S.get_posY() * 20), (S.get_posX() * 20));
            }

            foreach (Segment S in game.Walls)
            {
                g.DrawImage(wall, (S.get_posY() * 20), (S.get_posX() * 20));
            }

            foreach (Segment S in game.Fruits)
            {
                g.DrawImage(fruit, (S.get_posY() * 20), (S.get_posX() * 20));
            }

        }
    }
}
