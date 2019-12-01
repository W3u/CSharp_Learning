using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashCodeDemo.ReasonOfOverrideGetHashCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCodeDemo.ReasonOfOverrideGetHashCode.Tests
{
    [TestClass()]
    public class PointWithoutOverrideGetHashCodeTests
    {
        [TestMethod()]
        public void GetHashCodeTest()
        {
            int i1 = 325;
            int i2 = 325;
            Dictionary<int, string> ints = new Dictionary<int, string>();
            ints.Add(i1, "[value = 325]");
            //ints.Add(i1, "[value = 325]"); // Duplicated key Exception

            bool ib1 = ints.ContainsKey(i1); // true
            bool ib2 = ints.ContainsKey(i2); // true


            PointWithoutOverrideGetHashCode point1 = new PointWithoutOverrideGetHashCode(3, 25);
            PointWithoutOverrideGetHashCode point2 = new PointWithoutOverrideGetHashCode(3, 25);
            bool b1 = point1.Equals(point2); // true
            bool b2 = point1.GetHashCode() == point2.GetHashCode(); // false

            Dictionary<PointWithoutOverrideGetHashCode, String> points = new Dictionary<PointWithoutOverrideGetHashCode, string>(5);
            points.Add(point1, "[x=3, y= 25]");
            //points.Add(point2, "[x=3, y= 25]"); // No Exception occurs

            bool b3 = points.ContainsKey(point1); // true
            // If we didn't override the GetHashCode() method, then we cannot find the key by point2, which is equals to point1.
            // Because they will never be considered equal in Dictionary.
            bool b4 = points.ContainsKey(point2); // false
        }
    }
}