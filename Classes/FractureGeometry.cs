using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;


namespace RowlandProject.Classes
{
    public class FractureGeometry
    {
        // public double Vn = 0;
        public double k1c= 0;
        public double hL = 0;
        public double ti = 0;
        public double AP = 0;
        public double As = 0;
        public double v = 0;
        public double b = 0;
        public double c = 0;
        public double d = 0;
        public double e = 0;
        public double f = 0;
        public double r = 0;
        public double Pb = 0;
        public double E = 0;
        public double qi = 0;
        public double K1c2 = 0;
        public double K1c3 = 0;
        public double o2 = 0;
        public double o3 = 0;
        public double o1 = 0;
        public double Yv = 0;
        public double df = 0;
        public double ko = 0;
        public double Ahf = 0;
        public double arc = 0;

        public double G = 0;
        public double APp = 0;
        public double Pp = 0;
        public double oh = 0;
        public double u = 0;
        //public double erF = 0;
        public double diff_coefficient = 0;
        public double c_length = 0;
        public double a_biotConstant = 0;
        public double t = 0;
        public double oH = 0;
        public double ov = 0;
        public double i = 0;
        public double a = 0;
        public double hf = 0;



        //new stuff
        public double h = 0;
        public double width = 0;
        public double Pfriction = 0;
        public double q = 0;
        public double CL = 0;
        public double Sp = 0;

        public double ErrFunc(double x)
        {
            double t = 1.0 / (1.0 + 0.5 * Math.Abs(x));
            //Use Horner's method to compute the polynomial approximation
            double ans = 1 - t * Math.Exp(-x * x - 1.26551223 + t * (1.00002368 + t * (0.37409196 + t * (0.09678418 + t * (-0.18628806 + t * (0.27886807 + t * (-1.13520398 + t * (1.48851587 + t * (-0.82215223 + t * (0.17087277))))))))));
            if (x >= 0)
            {
                return ans;
            }
            else
            {
                return -ans;
            }

        }

        public double Lf()
        {
            double a = 2* Math.PI * Wr() * hf / 4;
            double b = 6 * CL * hf * Math.Sqrt(t);
            double c = 4 * hL * Sp;
            return 5.615 * q * t / (a + b + c);
        }
        public double Wr()
        {
            double a = (1 - (2 * u)) * hf;
            double b = Pi() - oh;
            double c = 2 * (Pi() - Pp) * n() * Ft();
            double d = 2 * n() * Ft() * APp;
            double e = Yh() * APp;
            return a * (b - c - d + e) / (4 * (1 - u) * G)*3.142;
        }

        public double Yh()
        {
            /*double a = a_biotConstant * ((1 - (2 * u)) / (1 - u));
            double b = e_ratio() / (2 * Math.Sqrt(Math.Pow((1 - (Math.Pow(e_ratio(), 2))), 3)));
            double b1 = Math.Cosh(e_ratio());
            double b2 = e_ratio() * Math.Sqrt(1 - Math.Pow(e_ratio(), 2));
            return a * (1 - (b * (b1 - b2)));*/

            double a = a_biotConstant * ((1 - (2 * u)) / (1 - u));

            double x1 = 1 - (Math.Pow(e_ratio(), 2));
            double x2 = Math.Pow(x1, 3);
            double x3 = 2* Math.Sqrt(x2);
            double b = e_ratio() / x3;

            double c = Math.Acos(e_ratio());

            double d = e_ratio() * Math.Sqrt(1 - Math.Pow(e_ratio(), 2));

            return a * (1 - (b * (c - d)));
        }

        public double e_ratio()
        {
            return h / width;
        }
        public double Pnet()
        {
            return Pfriction + Pp - oh;
        }

        public double Ft()
        {
            double a = (1 - (Math.Exp(Math.Pow(-Rh(), -1))));
            double b = 1 - (ErrFunc(1 / Math.Sqrt(Rh())));
            return (Math.Sqrt(Rh() / Math.PI) * a) + b;
        }

        public double Pi()
        {
            return Pnet() + (0.5 * (Oxo() + Oyo()));
        }

        public double Rh()
        {

            return (4 * diff_coefficient * t) / (c_length * c_length);
        }

        public double Oxo()
        {
            double result = (Math.Pow(lxx(), 2) * oH) + (Math.Pow(lxy(), 2) * oh) + (Math.Pow(lxz(), 2) * ov);
            return result;
        }

        public double Oyo()
        {
            double result = (Math.Pow(lyx(), 2) * oH) + (Math.Pow(lyy(), 2) * oh) + (Math.Pow(lyz(), 2) * ov);
            return result;
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
        public double n()
        {

            return (a_biotConstant * (1 - (2 * u))) / (2 * (1 - u));
        }

        //
        //
        //
        public double Q()
        {
            double upper = Math.PI * AP * ((8*Math.Pow(Wf(),4)*hf) * (3*Math.Pow(Wf(),4)*Ahf));
            return upper/(48*v*Lf());
        }
        public double VL()
        {
            //integration equation that needs to be solved
            return 6;
        }
        public double Kmd()
        {
            return ko / (1 + (df * ko));

        }
        public double Wf()
        {
            double a = (1 - (2 * u)) * hf;
            double b = (Pi()-oh)-(2*(Pi()-Pp)*n()*Ft());
            return a*b/(4*(1-u)*G);

        }
        public double AOv()
        {
            return Yv1()*AP;
        }
        public double AOH()
        {
            return YH1()*AP;
        }
        public double AOh()
        {
            return Yh1()*AP;
        }
        public double Yv1()
        {
            return Yv-a_biotConstant;
        }

        public double Yh1()
        {
            return Yh()-a_biotConstant;
        }
        public double YH1()
        {
            return YH()-a_biotConstant;
        }
        public double YH()
        {
            return Yh()-((Yh()-Yv)*((oh-oH)/(oh-ov)));
        }
       
        /*public double hf()
        {
            double a = K1c23() * Math.Sqrt(Math.PI);
            double b = (Math.PI * (Pi()-o23()))+((2*(o23()-o1))*Math.Sinh(1));
            double c = a / b;
            return 2 * Math.Pow(c, 2);
        }*/

        public double o23()
        {
            return 0.5 * (o2 + o3);
        }

        public double K1c23()
        {
            return 0.5*(K1c2+K1c3);
        }

      
        public double qti()
        {
            double a = Math.PI * Wf() * hf * Lf()/4;
            double b = Kmd() * AP * As * t / (v * Lf());
            return a + b;
        }

       
        
        
    }
}
