using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using static SnakeGame.GameWindow;

/// <summary>
///  10x10 px
///  250 x 250 px (25 x 25 elements)
/// </summary>

namespace SnakeGame
{
    public class Game: Panel
    {
        public String mode { get; set; }
        public List<Segment> Walls { get; set; }
        public List<Segment> theSnake { get; set; }
        public List<Segment> Fruits { get; set; }
        //public static System.Windows.Forms.Timer myTimer;

<<<<<<< HEAD
        public int last_posX;
        public int last_posY;

        public const int EASY_SPEED = 2;
        public const int HARD_SPEED= 1;
=======
       // public const int EASY_SPEED = 2;
       // public const int HARD_SPEED= 1;

        public int direction = RIGHT;
>>>>>>> 85cbe92000089b79ea3cec5201c6b25f10f7e910

        public const int square = 20;

        public int[,] grid = new int[square, square];

        public char key;

        public Game(String mode)
        {
            this.mode = mode;
            theSnake = new List<Segment>();
            Walls = new List<Segment>();
            Fruits = new List<Segment>();

            Random axis = new Random();

            // Création de la grille
            build_grid(square);

            for(int i=0; i<5; i++)
            {
                int x = axis.Next(0, square);
                int y = axis.Next(0, square);
                Grow_Snake(x, y);
            }

            for (int i = 0; i < 10; i++)
<<<<<<< HEAD
            Build_Wall(square);
            Put_fruit(square);
=======
                Build_Wall(square, grid);
                Put_fruit(square, grid);
>>>>>>> 85cbe92000089b79ea3cec5201c6b25f10f7e910
            foreach (Segment S in theSnake)
                grid[S.get_posX(), S.get_posY()] = S.segType;

            show_grid(grid, square);



          
        }


        public void Move_Snake()
        {
            switch (direction){
                case UP:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posX((S.get_posX() - 1));
                        if (S.get_posX() < 0)
                            S.set_posX(square);
                    }
                       
                    break;
                case DOWN:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posX((S.get_posX() + 1));
                        if (S.get_posX() == square)
                            S.set_posX(0);
                    }

                    break;
                case RIGHT:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posX((S.get_posY() + 1));
                        if (S.get_posY() == square)
                            S.set_posY(0);
                    }
                    break;
                case LEFT:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posX((S.get_posY() - 1));
                        if (S.get_posY() < 0)
                            S.set_posY(square);
                    }
                    break;
            }

        }

        /*
        public void TickRefresh()
        {
            //Console.WriteLine(string.Format("Boom changement de tick"));
            myTimer.Stop();

            ******************************************************
             *  Moves the snake in the direction the user pressed.
             *  ***************************************************

            ///// TO DO


            // Restarts the timer
            myTimer.Enabled = true;

        }
        */


        public void Grow_Snake(int x, int y) //adds a segment to the snake when it eats a fruit.
        {
            theSnake.Add(new Segment(x,y,Segment.SNAKE_BODY));
            this.Build_Wall(square);
            this.Put_fruit(square);
        }
        public void Build_Wall(int range) //adds a wall on the list of wall when the snake eats a fruit
        {
            Random axis = new Random();
            int x = axis.Next(0, range);
            int y = axis.Next(0, range);

            System.Console.WriteLine("Grid_Wall : " + grid[x, y]);


            if (grid[x, y] == 0)
            {
                grid[x, y] = 3;
                Walls.Add(new Segment(x, y, Segment.WALL));
            }
            else
                Build_Wall(range);
        }
        public void Put_fruit(int range) //adds a fruit on the list of fruit when the snake eats a fruit
        {
            Random axis = new Random();
            int x = axis.Next(0, range);
            int y = axis.Next(0, range);
            System.Console.WriteLine("Grid_Fruit : " + grid[x, y]);

            if (grid[x, y] == 0)
            {
                grid[x, y] = 2;
                Fruits.Add(new Segment(x, y, Segment.FRUIT));
            }
            else
                Put_fruit(range);
        }
        public void build_grid(int range)
        {
            int[,] grid = new int[range, range];
            for (int i = 0; i < range; i++)
                for(int j=0; j< range; j++)
                    grid[i, j] = 0;
        }
        public void show_grid(int[,] grid, int square)
        {
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    System.Console.Write(grid[i, j].ToString() + " ");
                }
                System.Console.WriteLine();
            }
        }
        public void eat_fruit(int range)
        {
            Random rand = new Random();
            int x = rand.Next(0, range);
            int y = rand.Next(0, range);

            if (theSnake[0].get_posX() == 2)
            {
                if (grid[x, y] == 0)
                {
                    Fruits[0].set_posX(x);
                    Fruits[0].set_posY(y);
                    Grow_Snake(last_posX, last_posY);
                    Build_Wall(range);
                }
                else
                    eat_fruit(range);
            }
        }
    }
}
