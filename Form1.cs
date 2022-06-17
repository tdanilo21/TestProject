using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        Vozilo[] vozila;
        bool igra = false, pocetak = true;

        private void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                int t = r.Next(3);
                (vozila[i], vozila[t]) = (vozila[t], vozila[i]);
            }
            int a = 3 * ClientRectangle.Height / 10;
            for (int i = 0; i < 3; i++)
            {
                vozila[i].Reset(new Point(0, a / 3 + i * a), a, Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)));
                vozila[i].Kreni(r.Next(5, 20));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vozila = new Vozilo[3];
            vozila[0] = new Auto();
            vozila[1] = new Motor();
            vozila[2] = new Dzip();
            Reset();
            timer1.Interval = 200;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 3; i++)
                vozila[i].Crtaj(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) vozila[i].Pomeri();
            Refresh();
            for (int i = 0; i < 3; i++)
            {
                if (vozila[i].Kraj(ClientRectangle.Width))
                {
                    igra = false;
                    timer1.Stop();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (igra) return;
            if (pocetak)
            {
                pocetak = false;
                igra = true;
                timer1.Start();
                button1.Text = "Reset";
            }
            else
            {
                pocetak = true;
                button1.Text = "Start";
                Reset();
                Refresh();
            }
        }
    }
}