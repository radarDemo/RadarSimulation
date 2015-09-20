using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace radarsystem
{
    public class Complex
    {
        //实部与虚部定义
        private double real;
        private double image;

        public Complex()
            : this(0, 0)
        {

        }

        public Complex(double real)
            : this(real, 0)
        {

        }

        public Complex(double real, double image)
        {
            this.real = real;
            this.image = image;
        }

        //geter and setter
        public double Real
        {
            get { return real; }
            set { real = value; }
        }

        public double Image
        {
            get { return image; }
            set { image = value; }
        }

        //重载方法
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real+c2.real,c1.image+c2.image);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.real - c2.real, c1.image - c2.image);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.real * c2.real - c1.image * c2.image, c1.image * c2.real + c1.real * c2.image);
        }

        //复数求模运算
        public double toModul()
        {
            return Math.Sqrt(real * real + image * image);
        }

        //重载toString方法
         public override string ToString()
        {
            if (Real == 0 && Image == 0)
            {
                return string.Format("{0}", 0);
            }
            if (Real == 0 && (Image != 1 && Image != -1))
            {
                return string.Format("{0} i", Image);
            }
            if (Image == 0)
            {
                return string.Format("{0}", Real);
            }
            if (Image == 1)
            {
                return string.Format("i");
            }
            if (Image == -1)
            {
                return string.Format("- i");
            }
            if (Image < 0)
            {
                return string.Format("{0} - {1} i", Real, -Image);
            }
            return string.Format("{0} + {1} i", Real, Image);
        }
    
    }
}
