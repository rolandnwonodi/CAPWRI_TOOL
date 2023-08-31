using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class BrittlenessAndFrac
    {
        public double Es = 0;
        public double u = 0;
       

        public double Br()
        {
            double br = (100 * ((Es + 1) / (Es - 1))) + (100 * ((0.4 - u) / 0.25));
            return br;
        }

        public double Fr()
        {
            double fr = 2*u/(1-(2*u));
            return fr;
        }

    }
}
