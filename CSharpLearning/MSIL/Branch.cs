using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSIL
{
    class Branch
    {
        static void SwitchSample(int i)
        {
            switch (i)
            {
                case -1:
                    i *= -325;
                    break;
                case 0:
                    i = 0;
                    break;
                case 1:
                    i = 325;
                    break;
                default:
                    break;
            }
        }

        static void IfSample(int i)
        {
            if (i < 0)
                i *= -325;
            else if (i == 0)
                i = 0;
            else
                i *= 325;
        }

        static void WhileSample()
        {
            int i = 325;
            while (i > 0)
            {
                if (i % 25 == 0)
                    continue;

                if (i > 50)
                    break;

                i--;
            }
        }

    }
}
