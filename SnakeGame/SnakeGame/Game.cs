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
    public class Game
    {
        public String mode { get; set; }
        public List<Segment> Walls { get; set; }
        public List<Segment> theSnake { get; set; }
        public List<Segment> Fruits { get; set; }
        //public static System.Windows.Forms.Timer myTimer;
        

        public int last_posX;
        public int last_posY;

        public int direction = RIGHT;

        public const int square = 25;

        public int[,] grid = new int[square+1, square+1];

        public char key;

        public int iteration = 0;

        public int score = 0;

        public bool game_over;

        Random axis = new Random();

        public Game(String mode)
        {
            this.mode = mode;
            theSnake = new List<Segment>();
            Walls = new List<Segment>();
            Fruits = new List<Segment>();

            game_over = false;


            // Création de la grille
            build_grid();
            Grow_Snake(10, 10);

            /***************************************
                  A ENLEVER EN FIN DE CODAGE :P
            ***************************************/
            /*for(int i=0; i<5; i++)
            {
                int x = axis.Next(0, square);
                int y = axis.Next(0, square);
                Grow_Snake(x, y);
            }*/

            for (int i = 0; i < 10; i++)
                Build_Wall();
            Put_fruit();


            show_grid();
            /***************************************
                  A ENLEVER EN FIN DE CODAGE :P
            ***************************************/

        }
        public void Move_Snake()
        {
            //show_grid();
            foreach(Segment S in theSnake)
            {
                S.last_posX = S.get_posX();
                S.last_posY = S.get_posY();
            }
            switch (direction){
                case UP:
                    theSnake[0].set_posX((theSnake[0].get_posX() - 1));
                    if (theSnake[0].get_posX() < 0)
                        theSnake[0].set_posX(square);
                       
                    break;
                case DOWN:
                    theSnake[0].set_posX((theSnake[0].get_posX() + 1));
                    if (theSnake[0].get_posX() == square)
                        theSnake[0].set_posX(0);

                    break;
                case RIGHT:
                    theSnake[0].set_posY((theSnake[0].get_posY() + 1));
                    if (theSnake[0].get_posY() == square)
                        theSnake[0].set_posY(0);
                    break;
                case LEFT:
                    theSnake[0].set_posY((theSnake[0].get_posY() - 1));
                    if (theSnake[0].get_posY() < 0)
                        theSnake[0].set_posY(square);
                    break;
            }
            for(int i =1; i<theSnake.Count; i++)
            {
                theSnake[i].set_posX(theSnake[i - 1].last_posX);
                theSnake[i].set_posY(theSnake[i - 1].last_posY);
            }
        }
        
        public void Grow_Snake(int x, int y) //adds a segment to the snake when it eats a fruit.
        {
            theSnake.Add(new Segment(x,y,Segment.SNAKE_BODY));
        }
        public void Build_Wall() //adds a wall on the list of wall when the snake eats a fruit
        {
            int x = axis.Next(0, square);
            int y = axis.Next(0, square);
            
            if (grid[x, y] == 0)
            {
                grid[x, y] = 3;
                Walls.Add(new Segment(x, y, Segment.WALL));
            }
            else
                Build_Wall();
        }
        public void Put_fruit() //adds a fruit on the list of fruit when the snake eats a fruit
        {
            Random axis = new Random();
            int x = axis.Next(0, square);
            int y = axis.Next(0, square);

            if (grid[x, y] == 0)
            {
                grid[x, y] = 2;
                Fruits.Add(new Segment(x, y, Segment.FRUIT));
            }
            else
                Put_fruit();
        }
        public void build_grid()
        {
            int[,] grid = new int[square, square];
            for (int i = 0; i < square; i++)
                for(int j=0; j< square; j++)
                    grid[i, j] = 0;
        }
        public void show_grid()
        {
            for (int i = 0; i < square; i++)
            {
                for (int j = 0; j < square; j++)
                {
                    System.Console.Write(grid[i, j].ToString() + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
        public void eat_fruit()
        {
            Random rand = new Random();
            int x = rand.Next(0, square);
            int y = rand.Next(0, square);

<<<<<<< HEAD
            if ((grid[theSnake[0].get_posX(), theSnake[0].get_posY()] == 2))
            {
                if (grid[x, y] == 0)
=======
            if(theSnake[0].get_posX()<square && theSnake[0].get_posY()<square)
                if (grid[theSnake[0].get_posX(), theSnake[0].get_posY()] == 2)
>>>>>>> fdd98644aa2eacc736596657f69292a8c0e66035
                {
                    System.Console.WriteLine("YEAH !");
                    if (grid[x, y] == 0)
                    {
                        Fruits[0].set_posX(x);
                        Fruits[0].set_posY(y);
                        Grow_Snake(last_posX, last_posY);
                        score = score + 100;

                        Build_Wall();

                    }
                    else
                        eat_fruit();
                }
            last_posX = theSnake[theSnake.Count - 1].get_posX();
            last_posY = theSnake[theSnake.Count - 1].get_posY();
        }
        public void update_grid()
        {
            for (int i = 0; i < square; i++)
                for (int j = 0; j < square; j++)
                    grid[i, j] = 0;
            foreach(Segment W in Walls)
            {
                grid[W.get_posX(), W.get_posY()] = 3;
            }
            foreach(Segment F in Fruits)
            {
                grid[F.get_posX(), F.get_posY()] = 2;
            }
        }
        public void die()
        {
            if (grid[theSnake[0].get_posX(), theSnake[0].get_posY()] == 3)
            {
                ScoreEntryForm SEF = new ScoreEntryForm(score);
                SEF.Show();
                game_over = true;
            }
        }
        public void update_snake()
        {
            score = score + 1;
            update_grid();
            Move_Snake();
            eat_fruit();

            die();
        }
    }
}
