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
        private int posX;

        private int posY;

        public int last_posX { get; set; }
        public int last_posY { get; set; }
        public int segType { get; set; }

        public const int SNAKE_BODY = 1;
        public const int FRUIT = 2;
        public const int WALL = 3;
        public const int SNAKE_HEAD = 4;

        public const int IMG_SIZE = 20;

        public Segment(int x, int y, int segType)
        {
            this.posX = x;
            this.posY = y;
            this.segType = segType;
            this.Location = new System.Drawing.Point((x * IMG_SIZE), (y * IMG_SIZE));
            this.Size = new System.Drawing.Size(IMG_SIZE, IMG_SIZE);
        }

        public int get_posX()
        {
            return this.posX;
        }
        public void set_posX(int x)
        {
            this.posX = x;
        }
        public int get_posY()
        {
            return this.posY;
        }
        public void set_posY(int y)
        {
            this.posY = y;
        }
    }
}
