using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class InjectionPressure
    {
        public double Pfrac = 0;
        public double a1 = 0;
        public double a2 = 0;
        public double a3 = 0;
        public double a4 = 0;
        public double Apfric = 0;
        public double Vbatch = 0;
        public double Pnet = 0;
        public double Pfric = 0;
        public double Q = 0;
        public double Pslurry = 0;
        public double Z = 0;
        public double oh = 0;

        public double K = 0;
        public double qi = 0;
        public double E = 0;
        public double Ee = 0;
        public double v = 0;

        public double a = 0;
        public double b = 0;
        public double c = 0;
        public double d = 0;
        public double e = 0;
        public double f = 0;



        public double Lf()
        {

            return Math.Pow(Pnet,a) * Math.Pow(K, b) * Math.Pow(qi, c) * Math.Pow(Ee, d) * Math.Pow(v, e) * Math.Pow(E, f);
        }

       
    }
}
