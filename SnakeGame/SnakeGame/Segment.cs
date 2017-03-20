using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public class Segment : PictureBox
    {
        private int posX { get; set; }
        private int posY { get; set; }
        private int segType { get; set; }

        public const int SNAKE_BODY = 1;
        public const int FRUIT = 2;
        public const int WALL = 3;
        public const int SNAKE_HEAD = 4;

        public Segment(int x, int y, int segType)
        {
            this.posX = x;
            this.posY = y;
            this.segType = segType;
        }
    }
}
