using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class NaturalFractureDens
    {
        public double G = 0;
        public double u = 0;
        public double k1c = 0;
        public double Q = 0;
        public double Ks = 0;
        public double Gs = 0;
        public double At = 0;
        public double T = 0;
        public double Ov = 0;
        public double OH = 0;
        public double Oh = 0;
        public double rw = 0;
        public double r = 0;
        public double O = 0;
        public double Phsp = 0;
        public double nt = 0;
        public double B = 0;
        public double a = 0;
        public double i = 0;
        public double OO = 0;
        public double Pn = 0;
        public double Vt = 0;
        public double Vn = 0;
        public double Pp = 0;

        public double R()
        {
            double a = (4*Math.Pow(G,2))*(1-Math.Pow(u,2));
            double b = (1 - (2 * u)) * Math.Pow(k1c, 2);
            return (a/b)*(Math.Pow(Eii(),2));
        }

        public double Eii()
        {
            double a = (Or()-Oo())/(2*G);
            double b = (Pt() - (Q * Pp)) / (3 * Ks * (1 - Q));
            double c = (Q*(Pt()-(Pp)))/((4*Gs)*(1-Q));
            double d = At * T;
            return a-b+c+d;

            //G AND GS 1087008.197
        }

        public double Pt()
        {
            double pt = Ov+OH+Oh;
            return pt;
        }

        public double Or()
        {
            double a =0.5* (Oxo()+Oyo())*(1-(Math.Pow(rw,2)/Math.Pow(r,2)));
            double b = 0.5 * (Oxo() + Oyo())*(1+(3*(Math.Pow(rw, 4)) /(Math.Pow(r, 4)))-(4*((Math.Pow(rw, 2)) /(Math.Pow(r, 2)))))* Math.Cos(Math.PI / 180 * (2 * O));
            double c = rxy()*(1+(3*Math.Pow(rw,4)/Math.Pow(r,4))-(4*Math.Pow(rw,2)/Math.Pow(r,2)))* (Math.Sin(Math.PI / 180 * (2 * O)));
            double d = (Math.Pow(rw, 2) / Math.Pow(r, 2) + Phsp);


            //double c = (1 + ((3 * (Math.Pow(rw, 4)))/Math.Pow(r,2)))*rxy()*(Math.Sin(2*O));
            //double e = (1 - 2 * u*nt*B/(1-u));

            double result = a + b + c + d;
            return result;
        }

        public double Oo()
        {
            double a = 0.5 * (Oxo()+Oyo()) * (1 + ((Math.Pow(rw,2)) / (r*r)));
            double b= 0.5 * (Oxo() - Oyo()) * (1 + ((Math.Pow(rw, 4)) / (r * r*r*r))*3) * (Math.Cos(Math.PI / 180 * (2*O)));
            double c = (1 + ((3 * (Math.Pow(rw, 4))) / Math.Pow(r, 4))) * rxy() * (Math.Sin(Math.PI / 180 * (2*O)));
            double d = (Math.Pow(rw, 2) / Math.Pow(r, 2) * Phsp);
            //double e = (1 - 2 * u) * nt * B / (1 - u);
            double result = a - b - c - d ;
            return result;
        }

        public double Oxo()
        {
            double result = (Math.Pow(lxx(),2)*OH) + (Math.Pow(lxy(), 2)*Oh) + (Math.Pow(lxz(), 2)*Ov);
            return result;
        }

        public double Oyo()
        {
            double result = (Math.Pow(lyx(), 2) * OH) + (Math.Pow(lyy(), 2) * Oh) + (Math.Pow(lyz(), 2) * Ov);
            return result;
        }

        public double rxy()
        {
            return (lxx()*lyx()*OH) + (lxy()*lyy()*Oh) + (lxz()*lyz()*Ov);
        }

        public double lxx()
        {
            double result = Math.Cos(Math.PI / 180 * a) * Math.Cos(Math.PI / 180 * i);
            return result;
        }

        public double lxy()
        {
            double result = Math.Sin(Math.PI / 180 * a) * Math.Cos(Math.PI / 180 * i);

            //  Math.Cos(Math.PI / 180 * angle)
            return result;
        }

        public double lxz()
        {
            double result = -1 * Math.Sin(Math.PI / 180 * i);
            return result;
        }

        public double lyx()
        {
            double result = -1 * Math.Sin(Math.PI / 180 * a);
            return result;
        }

        public double lyy()
        {
            double result = Math.Cos(Math.PI / 180 * a);
            return result;
        }

        public double lyz()
        {
           
            return 0;
        }

        public double lzx()
        {
            double result = Math.Cos(Math.PI / 180 * a) * Math.Sin(Math.PI / 180 * i);
            return result;
        }

        public double lzy()
        {
            double result= Math.Sin(Math.PI / 180 * a) * Math.Sin(Math.PI / 180 * i);
            return result;
        }

        public double lzz()
        {

            return Math.Cos(Math.PI / 180 * i);
        }

       /* public double Pp()
        {
            double result= OO - (OO - Pn) * Math.Pow(Vt / Vn,3);
            return result;
        }*/






       
    }
}
