using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class RheologyHydraulics
    {
        //Newttonian fluid
        public double P_newtonian = 0;
        public double q_newtonian = 0;
        public double k_newtonian = 0;
        public double n_newtonian = 0;
        public double ps_newtonian = 0;
        public double pf_newtonian = 0;
        public double ds_newtonian = 0;
        public double r_newtonian = 0;
        public double d_newtonian = 0;
        public double dp_newtonian = 0;
        public double dh_newtonian = 0;

        //Non Newtonian Fluid
        public double do_NonNewtonian = 0;
        public double pipe_roughness = 0;

        public double pipeType;


        //Newtonian Unknowns
        public double Ren_Newotonian()
        {
            double ren = 0;
            double upper = 1.86 * P_newtonian * Math.Pow(u_Newotonian(), (2 - n_newtonian))*Math.Pow((dh_newtonian-dp_newtonian),n_newtonian);
            double lower = k_newtonian * Math.Pow(12, n_newtonian) * Math.Pow(8,n_newtonian);
            if (pipeType == 0)
            {
              ren= (1.86 * P_newtonian * Math.Pow(u_Newotonian(), (2 - n_newtonian)) * Math.Pow(d_newtonian, n_newtonian))/ lower;
            }
            else if (pipeType == 1)
            {
                ren= upper / lower;
            }

            return ren;

        }
        public double F_Newotonian()
        {
            double f=0;
            if(Ren_Newotonian()<2100)
            {
                f= 16 / Ren_Newotonian();
            }
            else if(Ren_Newotonian() > 2100)
            {
                f= 0.079 / (Math.Pow(Ren_Newotonian(),0.25));
            }
            return f;
        }

        public double F_Non_Newotonian()
        {
            
            double f = 0;
            if (Ren_Newotonian() < 2100)
            {
                f = 24 / Ren_Newotonian();
            }
            else if (Ren_Newotonian() > 2100)
            {
                f = 0.079 / (Math.Pow(Ren_Newotonian(), 0.25));
            }
            else if (P_newtonian==0 || do_NonNewtonian==0)
            {
                double a = 2.28 - (4*Math.Log10(P_newtonian/do_NonNewtonian));
                f = (1 / a) * (1 / a);
            }
            return f;
        }
        public double v_Newotonian()
        {
            return 47850*k_newtonian*Math.Pow(r_newtonian,(n_newtonian-1));
        }
        public double u_Newotonian()
        {
            double u = 0;
            if (pipeType==0)
            {
                u= q_newtonian / 2.448 / Math.Pow(d_newtonian,2)*42;
            }
            else if (pipeType == 1)
            {
                u= q_newtonian / 2.448 / ((Math.Pow(dh_newtonian, 2)) - (Math.Pow(dp_newtonian, 2)))* 42;
            }
            return u;
        }
        public double Vsl_Newotonian()
        {
            double upper = 3*32.2 * ds_newtonian * Ren_Newotonian() * (ps_newtonian - pf_newtonian);
            double lower = 24 * pf_newtonian;
            return 0.667* Math.Sqrt(upper/lower);
        }
        public double Yf_Newotonian()
        {

            return ds_newtonian * (ps_newtonian - pf_newtonian) / 6;

        }

    }
}
