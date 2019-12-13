using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassParamsByRefOrValue
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    public struct Point
    {
        public int X { get; set; }

        public int Y { get; set; }
    }

}
