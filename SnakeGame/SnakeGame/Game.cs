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

        public int[,] grid = new int[square, square];

        public char key;

        public int iteration = 0;

        public Game(String mode)
        {
            this.mode = mode;
            theSnake = new List<Segment>();
            Walls = new List<Segment>();
            Fruits = new List<Segment>();

            Random axis = new Random();

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


            show_grid(grid, square);
            /***************************************
                  A ENLEVER EN FIN DE CODAGE :P
            ***************************************/

        }
        public void Move_Snake()
        {
            System.Console.WriteLine(direction);
            switch (direction){
                case UP:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posY((S.get_posY() - 1));
                        if (S.get_posY() < 0)
                            S.set_posY(square-1);
                    }
                       
                    break;
                case DOWN:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posY((S.get_posY() + 1));
                        if (S.get_posY() == square)
                            S.set_posY(0);
                    }

                    break;
                case RIGHT:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posX((S.get_posX() + 1));
                        if (S.get_posX() == square)
                            S.set_posX(0);
                    }
                    break;
                case LEFT:
                    foreach (Segment S in theSnake)
                    {
                        S.set_posX((S.get_posX() - 1));
                        if (S.get_posX() < 0)
                            S.set_posX(square-1);
                    }
                    break;
            }
            foreach (Segment S in theSnake)
            {
                iteration++;
                grid[S.get_posX(), S.get_posY()] = S.segType;
                System.Console.WriteLine(iteration + " - x = " + S.get_posX() + " - y = " + S.get_posY());
            }
            iteration = 0;
        }
        
        public void Grow_Snake(int x, int y) //adds a segment to the snake when it eats a fruit.
        {
            theSnake.Add(new Segment(x,y,Segment.SNAKE_BODY));
        }
        public void Build_Wall() //adds a wall on the list of wall when the snake eats a fruit
        {
            Random axis = new Random();
            int x = axis.Next(0, square);
            int y = axis.Next(0, square);

            System.Console.WriteLine("Grid_Wall : " + grid[x, y]);


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
            System.Console.WriteLine("Grid_Fruit : " + grid[x, y]);

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
        public void eat_fruit()
        {
            Random rand = new Random();
            int x = rand.Next(0, square);
            int y = rand.Next(0, square);

            if (grid[theSnake[0].get_posX(), theSnake[0].get_posY()] == 2)
            {
                if (grid[x, y] == 0)
                {
                    Fruits[0].set_posX(x);
                    Fruits[0].set_posY(y);
                    Grow_Snake(last_posX, last_posY);
                    Build_Wall();
                }
                else
                    eat_fruit();
            }
        }
        public void die()
        {
            if (grid[theSnake[0].get_posX(), theSnake[0].get_posY()] != 0 ||
                grid[theSnake[0].get_posX(), theSnake[0].get_posY()] != 2)
            {

            }
        }
        public void update_snake()
        {
            Move_Snake();
            eat_fruit();
            die();
        }
    }
}
