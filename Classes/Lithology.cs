using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class Lithology
    {
        public double tf = 0;
        public double t= 0;
        public double Pb = 0;

        public double Pf = 0;
        public double QNf = 0;
        public double QN = 0;

        public double M()
        {
            double m = 0.01*((tf-t)/(Pb-Pf));
            return m;
        }
        public double N()
        {
            double n = (QNf- QN) /(Pb- Pf);
            return n;
        }
    }
}
