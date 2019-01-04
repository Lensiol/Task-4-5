using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Resources;

namespace Task4_
{

    public partial class Form_Draw : Form
    {
        Graphics g;
        Bitmap bmp;
        World w;
        Thread thread;

        public Form_Draw()
        {
            InitializeComponent();
            Mechanic.Image = new Bitmap(Properties.Resources.Mechanic);
            Conveyor.rd = Invalidate;
            w = new World(Invalidate)
            {
                Mechanic = new Mechanic(240, 480)
            };
            World.locker = w.Mechanic;         
            World.locker = w.Mechanic;
            Conveyor.Image = new Bitmap(Properties.Resources.Detail);
            thread = new Thread(w.Update);
            thread.Start();
        }


        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(bmp);
            w.Mechanic.Draw(g);
            for (int i = 0; i < w.ListO.Count; i++)
            {
                {
                    w.ListO[i].Conveyor.Draw(g);
                }
            }
            e.Graphics.DrawImage(bmp, 0, 0);
            g.Dispose();
            bmp.Dispose();
            pictureBox.Invalidate();
        }

        private void Form_Draw_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Conveyor.XtoGO = e.X;
            Conveyor.YtoGO = e.Y;
        }      
    }
}
