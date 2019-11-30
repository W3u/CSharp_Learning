using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualityAndIdentityDemo.ValueEqualityViaReferenceType
{
    /// <summary>
    /// Represents a 2D point.
    /// </summary>
    public class TwoDPoint : IEquatable<TwoDPoint>
    {

        public TwoDPoint(int x, int y)
        {
            if (x < 1 || x > 2000
                || y < 1 || y > 2000)
            {
                throw new ArgumentOutOfRangeException("Point must be in range 1- 2000");
            }

            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }


        public bool Equals(TwoDPoint other)
        {
            // Step1: If the other argument is null, return false.
            // Note that no need to check whether this is null or not, the current object identified by this
            // is obviously not null when the nonstatic Equals method is called.
            // Note that we cannot invoke operator == here to the null check, 
            // because we will overload the operator ==(in that case, it will result in StackOverflow Exception).
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            // Step2: If the this and other argument refer to the same object, return true.
            // This step can improve performance when camparing objects with many fields.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // Step3: If the this and other argument refer to the objects of different types, retur false.
            // Even the method requires an instance of the TwoDPoint type, but we also need to check the its type to avoid its derived type be passed in, like Three3DPoint
            // Example:
            //              TwoDPoint point1 = new TwoDPoint(3, 25);
            //              ThreeDPoint point3 = new ThreeDPoint(0, 3, 25);
            //              bool b2 = point1.Equals(point3);
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Step4: Check each instance field defined by the type, compare the value in the this object 
            // with the value in the other argument. if any fields are not equal, reture false.
            return (this.X == other.X
                && this.Y == other.Y);

            // Step5: Call the Equals method of the base class so that it can compare any fields definedby by it.
            // Note that the base class is not invoked because it is System.Object, which defines Equals as Reference equality.
        }

        /// <summary>
        /// On classes (reference types), the default implementation of both Object.Equals(Object) methods 
        /// performs a reference equality comparison, not a value equality check. 
        /// When an implementer overrides the virtual method, the purpose is to give it value equality semantics.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Internally call the type-safe Equals method
            TwoDPoint other = obj as TwoDPoint;
            return Equals(other);
        }

        /// <summary>
        /// The == and != operators can be used with classes even if the class does not overload them.
        /// However, the default behavior is to perform a reference equality check. 
        /// In a class, if you overload the Equals method, you should overload the == and != operators, 
        /// but it is not required.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static bool operator ==(TwoDPoint point1, TwoDPoint point2)
        {
            if (Object.ReferenceEquals(point1, null))
            {
                if (Object.ReferenceEquals(point2, null))
                {
                    // null == null is true
                    return true;
                }
                // Only the left side is null.
                return false;
            }

            // Internally call the type-safe Equals method,
            // which handles case of null on the right side(point2 here).
            return point1.Equals(point2);
        }

        // A user-defined type can overload the == and != operators. If a type overloads one of the two operators, it must also overload another one.
        public static bool operator !=(TwoDPoint point1, TwoDPoint point2)
        {
            return !(point1 == point2);
        }

        // Override Object.GetHashCode so that two objects that have value equality produce the same hash code.
        public override int GetHashCode()
        {
            return X * 0x00010000 + Y;
        }
    }

    /// <summary>
    /// For the sake of simplicity, assume a ThreeDPoint IS a TwoDPoint
    /// </summary>
    public class ThreeDPoint : TwoDPoint, IEquatable<ThreeDPoint>
    {
        public ThreeDPoint(int x, int y, int z)
            : base(x, y)
        {
            if (z < 1 || z > 2000)
            {
                throw new System.ArgumentException("Point must be in range 1 - 2000");
            }

            this.Z = z;
        }

        public int Z { get; private set; }

        public bool Equals(ThreeDPoint other)
        {
            // Step1: If the other argument is null, return false.
            // Note that no need to check whether this is null or not, the current object identified by this
            // is obviously not null when the nonstatic Equals method is called.
            // Note that we cannot invoke operator == here to the null check, 
            // because we will overload the operator ==(in that case, it will result in StackOverflow Exception).
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            // Step2: If the this and other argument refer to the same object, return true.
            // This step can improve performance when camparing objects with many fields.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // Step3: If the this and other argument refer to the objects of different types, retur false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Step4: Check each instance field defined by the type, compare the value in the this object 
            // with the value in the other argument. if any fields are not equal, reture false.
            if (this.Z != other.Z)
            {
                return false;
            }
            // Step5: Call the Equals method of the base class so that it can compare any fields definedby by it.
            return base.Equals(other);
        }

        /// <summary>
        /// On classes (reference types), the default implementation of both Object.Equals(Object) methods 
        /// performs a reference equality comparison, not a value equality check. 
        /// When an implementer overrides the virtual method, the purpose is to give it value equality semantics.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            ThreeDPoint other = obj as ThreeDPoint;
            return this.Equals(other);
        }

        /// <summary>
        /// The == and != operators can be used with classes even if the class does not overload them.
        /// However, the default behavior is to perform a reference equality check. 
        /// In a class, if you overload the Equals method, you should overload the == and != operators, 
        /// but it is not required.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static bool operator ==(ThreeDPoint point1, ThreeDPoint point2)
        {
            if (Object.ReferenceEquals(point1, null))
            {
                if (Object.ReferenceEquals(point2, null))
                {
                    // null == null is true
                    return true;
                }
                // Only the left side is null.
                return false;
            }

            // Internally call the type-safe Equals method,
            // which handles case of null on the right side(point2 here).
            return point1.Equals(point2);
        }

        // A user-defined type can overload the == and != operators. If a type overloads one of the two operators, it must also overload another one.
        public static bool operator !=(ThreeDPoint point1, ThreeDPoint point2)
        {
            return !(point1 == point2);
        }

        // Override Object.GetHashCode so that two objects that have value equality produce the same hash code.
        public override int GetHashCode()
        {
            return (X * 0x100000) + (Y * 0x1000) + Z;
        }
    }

}
