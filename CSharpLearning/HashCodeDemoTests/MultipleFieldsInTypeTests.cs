using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashCodeDemo.MultipleFieldsInType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodeDemo.MultipleFieldsInType.Tests
{
    [TestClass()]
    public class PointTests
    {
        [TestMethod()]
        public void GetHashCodeTest()
        {
            Point point1 = new Point(3, 25);
            Point point2 = new Point(25, 3);
            bool b1 = point1.GetHashCode() == point2.GetHashCode(); // true

            Tuple<int, int> obj1 = new Tuple<int, int>(3, 25);
            Tuple<int, int> obj2 = new Tuple<int, int>(25, 3);
            bool b2 = obj1.GetHashCode() == obj2.GetHashCode(); // false
        }
    }
}