using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Task4_
{
    public class Mechanic : Moving,IMechanic
    {
        public static Bitmap Image { get; set; }
        public Task TMove { get; set; }
        public List<Conveyor> CList { get; set; }
        public int startX;
        public int startY;

        public Mechanic(int x,int y):base(x,y)
        {
            startX = x;
            startY = y;
            X = x;
            Y = y;
            CList = new List<Conveyor>();
            TMove = new Task(() =>
            {
                while (true)
                {
                    GoTO_C();
                    World.rd();
                    Thread.Sleep(10);
                }
            });
            TMove.Start();
        }

        public void Fix(Conveyor c)
        {
            Thread.Sleep(200);
            c.temp = true;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, X, Y, 150, 150);
        }

        public void GoTO_C()
        {
            if(CList.Count > 0)
            {
                if ((Math.Sqrt((CList[0].X - X) * (CList[0].X - X) + (CList[0].Y - Y) * (CList[0].Y - Y)) > 100))
                {
                    if (CList[0].Y > 500)
                    {
                        if (CList[0].X < X)
                            Move(-1, 0);
                        else
                            Move(1, 0);
                    }
                }

                else
                {
                    Fix(CList[0]);
                    CList.RemoveAt(0);
                }
            }
            else
            {
                if (Math.Sqrt(startX - X) * (startX - X) + (startY - Y) * (startY - Y) > 10)
                {
                    Move(5, 0);
                }
            }
        }

        public void AddC(Conveyor c)
        {
            Monitor.Enter(World.locker);
            CList.Add(c);
            Monitor.Exit(World.locker);
        }

    }
}
