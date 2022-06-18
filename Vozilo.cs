using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WinFormsApp1
{
    abstract class Riba
    {
        protected Point p;
        protected int a, brzina;
        protected Color c;

        public Riba(Point _p, int _a, int b, Color _c)
        {
            if (a <= 0) throw new Exception("Velicina <= 0");
            p = _p;
            a = _a;
            Brzina = b;
            c = _c;
        }

        public int Brzina
        {
            set
            { 
                if (value == 0) throw new Exception("Brzina ne sme biti 0.");
                brzina = value;
            }
        }

        protected int Operator(int a) { return p.X + (brzina > 0 ? a : -a); }

        protected abstract int Duzina();

        public void Pomeri() { p.X += brzina; }

        public bool Kraj(int x)
        {
            if (brzina > 0) return p.X + Duzina() > x;
            return p.X - Duzina() < x;
        }

        public abstract void Crtaj(Graphics g);
    }

    class Riba1 : Riba
    {
        public Riba1(Point _p, int _a, int b, Color _c) : base(_p, _a, b, _c) { }
        protected override int Duzina(){ return 6 * a; }
        public override void Crtaj(Graphics g)
        {
            SolidBrush cetka = new SolidBrush(c);
            Pen olovka = new Pen(Color.Black);
            Point[] points = { new Point(Operator(6 * a), p.Y), new Point(p.X, p.Y - 6 * a), new Point(p.X, p.Y + 6 * a) };
            g.FillPolygon(cetka, points);
            g.DrawPolygon(olovka, points);

            cetka.Color = Color.White;
            points[0] = new Point(Operator(5 * a / 2), p.Y - 7 * a / 2);
            points[1] = new Point(p.X, p.Y - 6 * a); points[1] = new Point(p.X, p.Y - 7 * a / 2);
            g.FillPolygon(cetka, points);
            g.DrawPolygon(olovka, points);

            points[0] = new Point(Operator(5 * a / 2), p.Y + 7 * a / 2);
            points[1] = new Point(p.X, p.Y + 6 * a); points[2] = new Point(p.X, p.Y + 7 * a / 2);
            g.FillPolygon(cetka, points);
            g.DrawPolygon(olovka, points);
        }
    }
}
