using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class EstimstionOfMAASPInjection
    {
        public double qLOT = 0;
        public double MASTP = 0;
        public double Pt = 0;
        public double qMASTP = 0;
        public double Zcsg = 0;
        public double Pslurry = 0;
        public double LOP = 0;
        public double Zshoe = 0;

        public double qi()
        {
            double upper = (qMASTP * (Pt - MAASP())) + (qLOT*(MASTP-Pt));
            return upper/(MASTP-MAASP());
        }
        public double MAASP()
        {
            return 0.052*Zcsg*(Pmax()-Pslurry);
        }
        public double Pmax()
        {
            return (LOP/(0.052*Zshoe))+Pslurry;
        }
    }
}
