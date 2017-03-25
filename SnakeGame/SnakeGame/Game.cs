﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
///  10x10 px
///  250 x 250 px (25 x 25 elements)
/// </summary>

namespace SnakeGame
{
    public class Game: Panel
    {
        private String mode { get; set; }
        private List<Segment> Walls { get; set; }
        private List<Segment> theSnake { get; set; }

        public const int EASY_SPEED = 1;
        public const int HARD_SPEED= 2;
        

        public Game(String mode)
        {
            int iteration = 0;
            this.mode = mode;
            theSnake = new List<Segment>();

            /********************************
            * Varaibles needed for the Grid *
            ********************************/
            const int square = 30;
            int[,] grid = new int[square, square];
            int[,] walls = new int[square, square];
            Random axis = new Random();

            // Création de la grille
            grid = build_grid(square);

            for(int i=0; i<5; i++)
            {
                int x = axis.Next(0, square);
                int y = axis.Next(0, square);
                Grow_Snake(x, y);
            }

            for (int i = 0; i < 10; i++)
                Build_Wall(square, grid);
            Put_fruit(square, grid);
            foreach (Segment S in theSnake)
                grid[S.get_posX(), S.get_posY()] = S.segType;

            show_grid(grid, square);
        }
        public void Grow_Snake(int x, int y) //adds a segment to the snake when it eats a fruit.
        {
            theSnake.Add(new Segment(x,y,Segment.SNAKE_BODY));
        }
        public void Build_Wall(int range, int[,] grid) //adds a wall on the list of wall when the snake eats a fruit
        {
            Random axis = new Random();
            int x = axis.Next(0, range);
            int y = axis.Next(0, range);
            System.Console.WriteLine("Grid_Wall : " + grid[x, y]);
            if (grid[x, y] == 0)
                grid[x, y] = 3;
            else
                Build_Wall(range, grid);
        }
        public void Put_fruit(int range, int[,] grid) //adds a wall on the list of wall when the snake eats a fruit
        {
            Random axis = new Random();
            int x = axis.Next(0, range);
            int y = axis.Next(0, range);
            System.Console.WriteLine("Grid_Fruit : " + grid[x, y]);
            if (grid[x, y] == 0)
                grid[x, y] = 2;
            else
                Put_fruit(range, grid);
        }
        public int[,] build_grid(int range)
        {
            int[,] grid = new int[range, range];
            for (int i = 0; i < range; i++)
                for(int j=0; j< range; j++)
                    grid[i, j] = 0;
            return grid;
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
    }
}
