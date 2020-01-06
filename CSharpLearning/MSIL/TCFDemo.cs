using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSIL
{
    class TCFDemo
    {
        static void Sample()
        {
            try
            {
                int a = 1, b = 3;
                int result = a / b;
            }
            catch (DivideByZeroException dbz)
            {
                throw dbz;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Completed!");
            }
        }
    }
}
