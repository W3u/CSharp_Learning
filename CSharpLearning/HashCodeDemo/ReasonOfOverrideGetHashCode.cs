using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCodeDemo.ReasonOfOverrideGetHashCode
{
    public class PointWithoutOverrideGetHashCode
    {
        private int x;
        private int y;

        public PointWithoutOverrideGetHashCode(int x, int y)
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

            PointWithoutOverrideGetHashCode other = (PointWithoutOverrideGetHashCode)obj;
            return this.x == other.x
                && this.y == other.y;
        }

        /// <summary>
        /// The example(see its corresponding test method) used to illustrate that
        /// why do we need to override the GetHashCode when the Equals method is overridden?
        /// 
        /// [Reason]
        /// Need to perform like the Value Type
        /// If we look into the implementation of the Dictionary class, 
        /// we will find it determines the equality via both the hashCode field and the Equals() method.
        ///     Dictionary.cs:  if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
        /// 
        /// Note that ,in below method, we directyly call the default implementation to obtain HashCode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
