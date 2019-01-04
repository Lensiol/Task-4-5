using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Task4_
{
    public delegate void Redrawing();

    public class Conveyor : Moving
    {
        public delegate void Action();
        public static Bitmap Image { get; set; }
        public static Redrawing rd;
        public Task TMove { get; set; }
        public bool temp { get; set; }
        public static int XtoGO { get; set; }
        public static int YtoGO { get; set; }
        public event Action DetailCrash;
        public static Random random = new Random();
        World w;

        public Conveyor(int x,int y, World w) :base(x,y)
        {
            this.w = w;
            temp = true;
            DetailCrash += () => 
            {
                temp = false;
                w.Mechanic.AddC(this);
            }; 
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, X, Y, 120,60);
        }

        public void Moving()
        {
            while (true)
            {
                MoveTo(XtoGO, YtoGO);
                rd();
                Thread.Sleep(20);
            }
        }
        public void MoveTo(int x, int y)
        {
            if (temp)
            {
                if (Math.Sqrt((x - X) * (x - X) + (y - Y) * (y - Y)) > 10)
                {
                    Move((int)(2 * Math.Cos(Math.Atan2(y - Y, x - X))),
                        (int)(-2 * Math.Sin(Math.Atan2(y - Y, x - X))));
                    if ((Conveyor.random.Next(0, 100000) < 100))
                        DetailCrash();
                }
            }
            else 
            {
                if (Math.Sqrt((X - X) * (X - X) + (560 - Y) * (560 - Y)) > 10)
                   Move(0,-1);     
            }

        }



        
    }
}
