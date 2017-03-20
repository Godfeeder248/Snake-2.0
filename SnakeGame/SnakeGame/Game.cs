﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<Segment> theSnake { get; set; }

        public const int EASY_SPEED = 1;
        public const int HARD_SPEED= 2;

        public Game(String mode)
        {
            this.mode = mode;
            theSnake = new List<Segment>();
        }

        public void Grow_Snake(int x, int y) //adds a segment to the snake when it eats a fruit.
        {
            theSnake.Add(new Segment(x,y,Segment.SNAKE_BODY));
        }
    }
}
