using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task4_
{
    public class Loader
    {
        public Conveyor Conveyor { get; set; }
        public event Action PultOn;
        public Loader(World w)
        {
            Conveyor = new Conveyor(0, 570,w);

            PultOn +=() =>
                {
                    Conveyor.TMove = new Task(() => Conveyor.Moving());
                    Conveyor.TMove.Start();
                };

            PultOn();
        }

    }
}
