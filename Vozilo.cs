using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WinFormsApp1
{
    abstract class Vozilo
    {
        protected Point p;
        protected int a;
        protected Color c;
        private int brzina;

        public Vozilo()
        {
            Reset(new Point(0, 0), 0, Color.Black);
        }
        public void Reset(Point _p, int _a, Color _c)
        {
            if (a < 0) throw new Exception("Duzina < 0!");
            p = _p;
            a = _a;
            c = _c;
            brzina = 0;
        }

        public void Kreni(int dx) { brzina = dx; }

        public void Pomeri() { p.X += brzina; }

        public bool Kraj(int x) { return p.X + a >= x; }

        public abstract void Crtaj(Graphics g);
    }

    class Auto : Vozilo
    {
        public override void Crtaj(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Red), p.X, p.Y, a, a);
        }
    }

    class Motor : Vozilo
    {
        public override void Crtaj(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Blue), p.X, p.Y, a, a);
        }
    }

    class Dzip : Vozilo
    {
        public override void Crtaj(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Green), p.X, p.Y, a, a);
        }
    }
}
