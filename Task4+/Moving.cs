using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task4_
{
    public abstract class Moving:IDraw
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Moving(int x,int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int dx,int dy)
        {
            X += dx;
            Y -= dy;
        }

        public abstract void Draw(Graphics g);
    }
}
