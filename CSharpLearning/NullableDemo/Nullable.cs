using System.Diagnostics.Contracts;

namespace NullableDemo
{
    /// <summary>
    /// Because we have special type system support that says a boxed Nullable<T> can be used where boxed<T> is use, Nullable can not implement any interfaces at all (since T may not).
    /// Do not add any interfaces to Nullable!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Nullable<T> where T : struct
    {
        /// <summary>
        /// 1. 如hasValue为false,则表示null(逻辑意义上,实际值可通过GetValueOrDefault()方法查询).
        /// 2. 如hasValue为true,则表示实际值.
        /// </summary>
        private bool hasValue;
        internal T value;

        /// <summary>
        /// Default ctor: If you instantiate a struct object using the parameterless constructor, all members are assigned according to their default values.
        /// 当实例化一个Nullable<T>为null时,CLR其实调用了它的无参默认构造函数来实例化了一个值类型(其value字段并不真为null).
        /// e.g. int? i = null;
        /// </summary>
        //public Nullable()
        //{
        //    this.value = default(T);
        //    this.hasValue = false;
        //}

        public Nullable(T value)
        {
            this.value = value;
            this.hasValue = true;
        }

        public bool HasValue
        {
            get
            {
                return hasValue;
            }
        }

        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new System.InvalidOperationException();
                }
                return value;
            }
        }

        public T GetValueOrDefault()
        {
            // if hasValue = false, then value would be default(T), that is 0
            return value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            return hasValue ? value : defaultValue;
        }

        public override bool Equals(object other)
        {
            if (!hasValue)
                return other == null;
            if (other == null)
                return false;
            return value.Equals(other);
        }

        public override int GetHashCode()
        {
            return hasValue ? value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return hasValue ? value.ToString() : "";
        }

        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }

        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }
    }

    public static class Nullable
    {
        public static int Compare<T>(Nullable<T> n1, Nullable<T> n2) where T : struct
        {
            if (n1.HasValue)
            {
                if (n2.HasValue)
                {
                    //return System.Collections.Comparer<T>.Default.Compare(n1.value, n2.value);
                }
                return 1;
            }
            if (n2.HasValue)
                return -1;

            return 0;
        }

        public static bool Equals<T>(Nullable<T> n1, Nullable<T> n2) where T : struct
        {
            if (n1.HasValue)
            {
                if (n2.HasValue)
                {
                    //return EqualityComparer<T>.Default.Equals(n1.value, n2.value);
                }
                return false;
            }
            if (n2.HasValue)
                return false;

            return true;
        }

        // If the type provided is not a Nullable Type, return null.
        // Otherwise, returns the underlying type of the Nullable type
        public static System.Type GetUnderlyingType(System.Type nullableType)
        {
            if ((object)nullableType == null)
            {
                throw new System.ArgumentNullException("nullableType");
            }
            Contract.EndContractBlock();
            System.Type result = null;
            if (nullableType.IsGenericType && !nullableType.IsGenericTypeDefinition)
            {
                // instantiated generic type only                
                System.Type genericType = nullableType.GetGenericTypeDefinition();
                if (System.Object.ReferenceEquals(genericType, typeof(Nullable<>)))
                {
                    result = nullableType.GetGenericArguments()[0];
                }
            }
            return result;
        }

    }

}
