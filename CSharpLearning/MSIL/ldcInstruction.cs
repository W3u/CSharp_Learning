using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSIL
{
    class ldcInstruction
    {
        static void LdcSample()
        {
            bool tr = true;
            bool fl = false;

            byte b1 = 25;

            short s1 = 325;

            int i1 = 3250;

            long l1 = 32500;

            Console.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}-{6}", tr, fl, b1, s1, i1, l1);


            
        }



    }
}
