using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowlandProject.Classes
{
    public class CaprockIntegrity
    {
        public double a = 0;
        public double i = 0;

        public double Pp = 0;
        public double Roz = 0;
        public double E = 0;
        public double at = 0;
        public double u = 0;
        public double Tw = 0;
        public double To = 0;
        public double B = 0;
        public double n = 0;
        public double OH = 0;
        public double Oh = 0;
        public double Ov = 0;
        public double Co = 0;
        public double Ol = 0;
        public double us = 0;
        public double df = 0;
        public double Erock = 0;
        public double ah = 0;
        public double h = 0;
        public double APr = 0;
        public double AT = 0;

        public double AP = 0;
        public double a_biotConstant = 0;
        public double width = 0;
        public double dd = 0;

        // the field ah= a_biotConstant

        public double lzx()
        {
            double result = Math.Cos(Math.PI / 180 * a) * Math.Sin(Math.PI / 180 * i);
            return result;
        }

        public double lzy()
        {
            double result = Math.Sin(Math.PI / 180 * a) * Math.Sin(Math.PI / 180 * i);
            return result;
        }

        public double lzz()
        {

            return Math.Cos(Math.PI / 180 * i);
        }

        public double Pfip()
        {
            double a = (36 * Q() * Q())-(24*Sf());
            double b = (6*Q())+Math.Sqrt(a);
            return b / 12;
        }

        public double Sf()
        {
            double a = 2 * (Math.Pow(Q(), 2) + Math.Pow(T(), 2) - (Q() * T()));
            double result = a - a1() - (0.5*b()*Q())+(b()*Pp)-(0.25*Q()*Q()*C())+(Q()*Pp*C())-(Pp*Pp*C())+(6* Roz* Roz);
            return result ;
        }
        public double Q()
        {
            double a = (3 * Oyo()) - Oxo();
            double b = E * at * (Tw - To) / (1 - u);
            double c = (1 - (2 * u)) * B * n / (1 - u);
            return a + b + c;
        }

        public double T()
        {
            double a = Ozo() - (2 * u*(Oxo()-Oyo()));
            double b = E * at * (Tw-To)/ (1-u);
            double c = (1 - (2 * u)) * B * n / (1 - u);
            return a + b + c;
        }

        public double Ozo()
        {
            return (lzx() * lzx() * OH) + (lzy() * lzy() * Oh) + (lzz()*lzz()*Ov);
        }


        public double a1()
        {

            return 8* Co *Co * Math.Cos(Math.PI / 180 * Ol) *Math.Cos(Math.PI / 180 * Ol);

            //return 8 * Co * Co * Math.Cos(Ol) * Math.Cos(Ol);

        }

        public double b()
        {
            return 16 * Co * Math.Sin(Math.PI / 180 * Ol) * Math.Cos(Math.PI / 180 * Ol);
        }

        public double C()
        {
            return 8* (Math.Sin(Math.PI / 180 * Ol) * ( Math.Sin(Math.PI / 180 * Ol)));
        }

        public double O()
        {
            double x1 = (-N() + Math.Sqrt(N() * N() - (4*M()*us)))/(2*M());
            double x2 = (-N() - Math.Sqrt(N() * N() - (4 * M() * us))) / (2 * M());

            if (x1>=0)
            {
                return Math.Atan(x1);
            }
            else if(x2 >= 0)
            {
                return Math.Atan(x2);

            }
            else
            {
                return Math.Atan(x1);
            }

        }

        public double M()
        {

            return us*Ro();
        }
        public double N()
        {
            return df*(Ro()-1);
        }

        public double Ro()
        {
            double upper = (dd - Yh1());
            double lower = (dd - Yv1());

            return upper/ lower;
        }

        public double AH()
        {
            double a_upper = (1 - (2 * u)) * (1 + u); ;
            double a_lower = (1 - u) * Erock;
            double b = ah * h * APr;
            double c = 3 * h * at * AT;

            double result = (a_upper / a_lower * b) + c;

            return result;
        }

        // we added this

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
        public double AOv()
        {
            return Yv1() * AP;
        }
        public double AOH()
        {
            return YH1() * AP;
        }
        public double AOh()
        {
            return Yh1() * AP;
        }
        public double Yv1()
        {
            return Yv() - a_biotConstant;
        }

        public double Yh1()
        {
            return Yh() - a_biotConstant;
        }
        public double YH1()
        {
            return YH() - a_biotConstant;
        }
        public double YH()
        {
            double a = (2*(1-(2*u))) / (1-u);
            return a-Yh()-Yv();
        }

        public double Yh()
        {

            /*double a = a_biotConstant * ((1 - (2 * u)) / (1 - u));
            double b = e_ratio() / (2 * Math.Sqrt(Math.Pow((1 - (Math.Pow(e_ratio(), 2))), 3)));
            double b1 = Math.Cosh(e_ratio());
            double b2 = e_ratio() * Math.Sqrt(1 - Math.Pow(e_ratio(), 2));
            return a *(1-(b*(b1-b2)));*/

            double a = a_biotConstant * ((1 - (2 * u)) / (1 - u));

            double x1 = 1 - (Math.Pow(e_ratio(), 2));
            double x2 = Math.Pow(x1, 3);
            double x3 = 2 * Math.Sqrt(x2);
            double b = e_ratio() / x3;

            double c = Math.Acos(e_ratio());

            double d = e_ratio() * Math.Sqrt(1 - Math.Pow(e_ratio(), 2));

            return a * (1 - (b * (c - d)));
        }
        public double Yv()
        {

            double a = a_biotConstant * ((1 - (2 * u)) / (1 - u));
            double b = e_ratio() / (Math.Sqrt(Math.Pow((1 - (Math.Pow(e_ratio(), 2))), 3)));
            double b1 = Math.Cosh(e_ratio());
            double b2 = e_ratio() * Math.Sqrt(1 - Math.Pow(e_ratio(), 2));
            return a * b *( b1-b2);
        }

        public double Oxo()
        {
            double result = (Math.Pow(lxx(), 2) * OH) + (Math.Pow(lxy(), 2) * Oh) + (Math.Pow(lxz(), 2) * Ov);
            return result;
        }

        public double Oyo()
        {
            double result = (Math.Pow(lyx(), 2) * OH) + (Math.Pow(lyy(), 2) * Oh) + (Math.Pow(lyz(), 2) * Ov);
            return result;
        }

        public double e_ratio()
        {
            return h / width;
        }

     
    }
}
