using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class GeomechanicalParameters
    {
        public double oo = 0;
        public double Av = 0;
        public double AH = 0;
        public double E = 0;
        public double Ey = 0;
        public double Ex = 0;
        public double a_biotCoeffiecnt = 0;
        public double To = 0;
        public double Pn = 0;
        public double vt = 0;
        public double vn = 0;
        public double Rt = 0;
        public double Rn = 0;
        public double t = 0;
        public double tma = 0;
        public double dg = 0;
        public double Ev = 0;
        public double Pb = 0;
        public double Atc = 0;
        public double Ats = 0;



        public double u()
        {
            double upper = (Math.Pow((Ats / Atc), 2)/2)-1;
            double lower = (Math.Pow((Ats / Atc), 2)) - 1;

            return upper/lower;
        }
        public double Ed()
        {
            double a = (3/Math.Pow(Atc, 2)) - (4 / Math.Pow(Ats, 2));
            double b = (Math.Pow((Ats / Atc), 2)) - 1;
            double c = 1.3468 * Math.Pow(10, 10) * Pb;
            return c*(a/b);
        }
        public double G()
        {
            return E * Math.Pow((2 + (2 * u())), -1);
        }
        public double K()
        {
            double a = 1.3468 * Math.Pow(10, 10) * Pb;
            double b = (1 / (Math.Pow(Atc, 2))) - (1 / (3 * Math.Pow(Ats, 2)));
            return a * b;
        }
        public double Es()
        {
            return (0.018*Math.Pow(Ed(),2))+(0.422*Ed());
        }

        public double Eh()
        {
            return 10.06 * Math.Pow(Ev, 0.406);
        }

        public double UCS()
        {
            return 14.035 * Math.Pow(E, 0.5734);
        }

        public double kmd()
        {
            double a = Math.Pow(O(), 3) / (180 * Math.Pow(1 - O(), 2));
            return Math.Pow(dg, 2) * a;
        }

        public double O()
        {
            return 0.067 * ((t - tma) / t);
        }

        public double Pp()
        {
            double a = (oo - Pn) * Math.Pow(vt / vn, 3);
            return oo - a;
        }

        public double oh()
        {
            double a = (u() / (1 - u()))*(oo-(a_biotCoeffiecnt*Pp()));
            return a + (a_biotCoeffiecnt * Pp()) + To;
        }

        public double oH()
        {
            double a = (u() / (1 - u())) * (oo - (Av * Pp()));
            return a + (AH * Pp()) + (E * Ey / (1 - (u() * u()))) + (E * u() * Ex / (1 - (u() * u())));
        }
    }
}
