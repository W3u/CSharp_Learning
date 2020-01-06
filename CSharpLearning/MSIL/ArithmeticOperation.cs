using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSIL
{
    class ArithmeticOperation
    {
        static void Add(int i, int j)
        {
            int result = i + j;
        }

        static void Sub(int i, int j)
        {
            int result = i - j;
        }

        static void Mul(int i, int j)
        {
            int result = i * j;
        }

        static void Div(int i, int j)
        {
            int result = i / j;
        }

        static void Mod(int i, int j)
        {
            int result = i % j;
        }

        static void Neg(int i)
        {
            int result = -i;
        }
    }
}
