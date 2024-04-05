using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Practice
{
    public class Rectangle
    {
        public virtual double Area(double a, double b)
        {
            return a * b;
        }
    }
    public class Triangle : Rectangle
    {
        public override double Area(double b, double h)
        {
            return 0.5*b*h;
        }

    }
}
