using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOST8
{
    class Grapher
    {
        public Graphics Graphics1 { get; set; }
        public Graphics Graphics2 { get; set; }
        public Graphics Graphics3 { get; set; }

        public void Clear()
        {
            Graphics1.Clear(Color.White);
            Graphics2.Clear(Color.White);
            Graphics3.Clear(Color.White);
        }

        public double Scale1 { get; set; }
        public int imX10 { get; set; }
        public int imY10 { get; set; }

        Vector3 B;
        Vector3 V;
        double t;
        Vector3 R;
        double q;
        double m;
        double dt;

        public void Build(double q, double m, Vector3 v0, Vector3 B, double dt, double Tmax)
        {
            this.q = q;
            this.m = m;
            this.B = B;
            this.R = new Vector3 { X = 0, Y = 0, Z = 0 };
            this.t = 0;
            this.dt = dt;
            V = v0;
            Vnext(v0, dt * 0.5); // v[1/2]

            do
            {
                Vector3 Rn = Rnext();
                Graphics1.DrawLine(new Pen(Color.Black, 1.5f),
                    new Point((int)(imX10 + R.X * Scale1), (int)(imY10 + R.Y * Scale1)),
                    new Point((int)(imX10 + Rn.X * Scale1), (int)(imY10 + Rn.Y * Scale1)));
                Graphics2.DrawLine(new Pen(Color.Black, 1.5f),
                    new Point((int)(imX10 + R.X * Scale1), (int)(imY10 + R.Z * Scale1)),
                    new Point((int)(imX10 + Rn.X * Scale1), (int)(imY10 + Rn.Z * Scale1)));
                Graphics3.DrawLine(new Pen(Color.Black, 1.5f),
                    new Point((int)(imX10 + R.Y * Scale1), (int)(imY10 + R.Z * Scale1)),
                    new Point((int)(imX10 + Rn.Y * Scale1), (int)(imY10 + Rn.Z * Scale1)));



                R = Rn;
                t += dt;
            }
            while (t < Tmax);
        }

        Vector3 Rnext() => R + Vnext(V, dt) * dt;

        Vector3 Vnext(Vector3 Vprev, double dt) =>  V = Vprev + A * dt; 

        Vector3 A => (q / m) * B.CrossProduct(V);  // основная формула 
    }
}
