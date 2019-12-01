using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCodeDemo.MultipleFieldsInType
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }
            if (this.GetType().Equals(obj.GetType()) == false)
            {
                return false;
            }

            Point other = (Point)obj;
            return this.x == other.x
                && this.y == other.y;
        }

        /* Implementation #1
        /// <summary>
        /// Frequently, a type has multiple data fields that can participate in generating the hash code. 
        /// One way to generate a hash code is to combine these fields using an XOR (eXclusive OR) operation.
        /// 
        /// Cons:
        ///     1. The previous example returns the same hash code for (n1, n2) and (n2, n1), 
        ///         and so may generate more collisions than are desirable. 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return x ^ y;
        }
        */

        /* Implementation #2
        /// <summary>
        /// Returns the hash code of a Tuple object that reflects the order of each field.
        /// Note, though, that the performance overhead of instantiating a Tuple object may significantly impact 
        /// the overall performance of an application that stores large numbers of objects in hash tables.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Tuple.Create(x, y).GetHashCode();
        }
        */

        /* Implementation #3
        /// <summary>
        /// Best Algorithm
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, x) ? x.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, y) ? y.GetHashCode() : 0);
                return hash;
            }
        }
        */


        /// <summary>
        /// VS auto-implemented
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }


    }
}
