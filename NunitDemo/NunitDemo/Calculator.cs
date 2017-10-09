using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemo
{
    public class Calculator
    {
        public static double Sum( double first, double second )
        {            
            return first + second;
        }

        public static double Res( double first, double second )
        {
            return first - second;
        }

        public static double Mult( double first, double second )
        {
            return first * second;
        }

        public static double Div( double first, double second )
        {
            if (second == 0) throw new DivideByZeroException();
            return first / second;
        }
    }
}
