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
        int n;
        Riba[] ribe;
        private void Form1_Load(object sender, EventArgs e)
        {
            n = r.Next(5, 15);
            ribe = new Riba[n];
            for (int i = 0; i < n; i++)
            {
                int a = r.Next(5, 15);
                Point p = new Point(r.Next(9 * a, ClientRectangle.Width - 9 * a), r.Next(13 * a, ClientRectangle.Height - 7 * a));
                int b = r.Next(5, 15);
                if (r.Next(2) > 0) b *= -1;
                Color c = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                int t = r.Next(3);
                ribe[i] = new Riba1(p, a, b, c);
            }
            timer1.Interval = 500;
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < n; i++)
                ribe[i].Crtaj(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                ribe[i].Pomeri();
                if (ribe[i].Kraj(ClientRectangle.Width))
                    ribe[i].Brzina *= -1;
            }
            Refresh();
        }
    }
}