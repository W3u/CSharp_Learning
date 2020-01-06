using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSIL
{
    class Program
    {
        static void Main()
        {
            CtorStruct demoS = new CtorStruct(15);
            demoS.ShowInterValue();

            CtorClass demoC = new CtorClass(15);
            demoC.ShowInterValue();
        }
    }

    struct CtorStruct
    {
        private Int32 mValue;

        public CtorStruct(int i)
        {
            mValue = i;
        }

        public void ShowInterValue()
        {
            Console.WriteLine(mValue);
        }
    }

    class CtorClass
    {
        private Int32 mValue;

        public CtorClass(int i)
        {
            mValue = i;
        }

        public void ShowInterValue()
        {
            Console.WriteLine(mValue);
        }

    }

}
