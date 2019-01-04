using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task4_
{
    public class World
    {
        public List<Loader> ListO { get; set; }
        public Mechanic Mechanic { get; set; }
        public delegate void Redrawing();
        public static Redrawing rd;
        public static object locker = new object();


        public World(Redrawing d)
        {
            rd = d;
            ListO = new List<Loader>();
        }

        public void Update()
        {
            float time = 0;
            while (true)
            {
                time += 1;
                if (time == 400)
                {
                    time = 0;
                    ListO.Add(new Loader(this));
                }
                Thread.Sleep(10);
            }
        }

    }
}
