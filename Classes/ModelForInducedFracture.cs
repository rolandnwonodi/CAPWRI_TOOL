using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class ModelForInducedFracture
    {
        public double u = 0;
        public double oo = 0;
        public double Pp = 0;
        public double Kic = 0;
        public double a = 0;
        public double Oxo = 0;
        public double Oyo = 0;
        public double O = 0;
        public double Pw = 0;
        public double OH = 0;
        public double Oh = 0;
        public double Ov = 0;
        public double Lxx = 0;
        public double Lyx = 0;
        public double Lxy = 0;
        public double Lyy = 0;
        public double Lxz = 0;
        public double Lyz = 0;



        public double FPP()
        {
            double a = (u / (1 - u)) * (oo - Pp);

            return a + Pp + To();
        }

        public double PFPP()
        {
            return Oh + (Kic / Math.Sqrt(Math.PI * a));
        }

        public double To()
        {
            return Oo() - Pp;
        }

        public double Oo()
        {
            return Oxo + Oyo - (2 * (Oxo - Oyo) * (Math.Cos(2 * O))) - (4 * rxyo() * Math.Sin(2 * O)) - Pw;
        }
        public double rxyo()
        {
            return (Lxx * Lyx * OH) + (Lxy * Lyy * Oh) + (Lxz * Lyz * Ov);
        }
    }
}
