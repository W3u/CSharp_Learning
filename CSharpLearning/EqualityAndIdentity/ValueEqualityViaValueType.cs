using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualityAndIdentity.ValueEqualityViaValueType
{
    public struct TwoDPoint : IEquatable<TwoDPoint>
    {
        public TwoDPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// For structs, the default implementation of Object.Equals(Object) (which is the overridden version in System.ValueType) 
        /// performs a value equality check by using reflection to compare the values of every field in the type.
        /// Because the CLR's reflection is slow, when defining your own value type, you should override 
        /// the Equals method and proivde your own implementation to improve the performance, do not call base.Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TwoDPoint other)
        {
            // Step1: No need to do this check, because it is not nullable.
            // If the other argument is null, return false.
            //if (Object.ReferenceEquals(other, null))
            //{
            //    return false;
            //}

            // Step2: For Value type, we don't need to do this check.
            //if (Object.ReferenceEquals(this, other))
            //{
            //    return true;
            //}

            // Step3: Value Type cannot inherit from other type(except interface).
            // If the this and other argument refer to the objects of different types, retur false.
            // Even the method requires an instance of the TwoDPoint type, but we also need to check the its type to avoid its derived type be passed in, like Three3DPoint
            // Example:
            //              TwoDPoint point1 = new TwoDPoint(3, 25);
            //              ThreeDPoint point3 = new ThreeDPoint(0, 3, 25);
            //              bool b2 = point1.Equals(point3);
            //if (this.GetType() != other.GetType())
            //{
            //    return false;
            //}

            // Step4: Check each instance field defined by the type, compare the value in the this object 
            // with the value in the other argument. if any fields are not equal, reture false.
            return (this.X == other.X
                && this.Y == other.Y);


            // Step5: Value Type cannot inherit from other type(except interface).
            //In other words, we dont need to invoke the Equals method of the base class.
            // Note that Object's Equals method cannot be called by ValueType's Equals method.
        }

        public override bool Equals(object obj)
        {
            if(obj is TwoDPoint)
            {
                // Unbox
                return this.Equals((TwoDPoint)obj);
            }
            // return false as well when obj is null.
            return false;
        }

        /// <summary>
        /// The == and != operators cannot operate on a struct unless the struct explicitly overloads them.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static bool operator ==(TwoDPoint point1, TwoDPoint point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(TwoDPoint point1, TwoDPoint point2)
        {
            return !(point1 == point2);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }


}
