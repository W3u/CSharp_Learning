using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 
 * You do not have to implement any custom logic to support reference equality comparisons in your types. 
 * This functionality is provided for all types by the static Object.ReferenceEquals method.
 * 
 * The example also shows why Object.ReferenceEquals always returns false for value types 
 * and why you should not use ReferenceEquals to determine string equality.
 * 
 * The implementation of Equals in the System.Object universal base class also performs a reference equality check, 
 * but it is best not to use this because, if a class happens to override the method, the results might not be what you expect. 
 * The same is true for the == and != operators. 
 * When they are operating on reference types, the default behavior of == and != is to perform a reference equality check. 
 * However, derived classes can overload the operator to perform a value equality check. 
 * To minimize the potential for error, it is best to always use ReferenceEquals when you have to determine whether two objects have reference equality.
 * 
 * Constant strings within the same assembly are always interned by the runtime. 
 * That is, only one instance of each unique literal string is maintained. 
 * However, the runtime does not guarantee that strings created at runtime are interned, 
 * nor does it guarantee that two equal constant strings in different assemblies are interned.
 */

namespace EqualityAndIdentity.ReferenceEqualityViaReferenceType
{
    struct TestStruct
    {
        public int Num { get; private set; }
        public string Name { get; private set; }

        public TestStruct(int i, string s) : this()
        {
            Num = i;
            Name = s;
        }
    }

    class TestClass
    {
        public int Num { get; set; }
        public string Name { get; set; }
    }

    /*
    class Program
    {
        static void Main()
        {
            // Demonstrate reference equality with reference types.
            #region ReferenceTypes

            // Create two reference type instances that have identical values.
            TestClass tcA = new TestClass() { Num = 1, Name = "New TestClass" };
            TestClass tcB = new TestClass() { Num = 1, Name = "New TestClass" };

            Console.WriteLine("ReferenceEquals(tcA, tcB) = {0}",
                                Object.ReferenceEquals(tcA, tcB)); // false

            // After assignment, tcB and tcA refer to the same object. 
            // They now have reference equality. 
            tcB = tcA;
            Console.WriteLine("After asignment: ReferenceEquals(tcA, tcB) = {0}",
                                Object.ReferenceEquals(tcA, tcB)); // true

            // Changes made to tcA are reflected in tcB. Therefore, objects
            // that have reference equality also have value equality.
            tcA.Num = 42;
            tcA.Name = "TestClass 42";
            Console.WriteLine("tcB.Name = {0} tcB.Num: {1}", tcB.Name, tcB.Num);
            #endregion

            
    
    
            // Demonstrate that two value type instances never have reference equality.
            #region ValueTypes

            TestStruct tsC = new TestStruct( 1, "TestStruct 1");

            // Value types are copied on assignment. tsD and tsC have 
            // the same values but are not the same object.
            TestStruct tsD = tsC;
            Console.WriteLine("After asignment: ReferenceEquals(tsC, tsD) = {0}",
                                Object.ReferenceEquals(tsC, tsD)); // false
            #endregion

            
    
    
            #region stringRefEquality
            // Constant strings within the same assembly are always interned by the runtime.
            // This means they are stored in the same location in memory. Therefore, 
            // the two strings have reference equality although no assignment takes place.
            string strA = "Hello world!";
            string strB = "Hello world!";
            Console.WriteLine("ReferenceEquals(strA, strB) = {0}",
                             Object.ReferenceEquals(strA, strB)); // true

            // After a new string is assigned to strA, strA and strB
            // are no longer interned and no longer have reference equality.
            strA = "Goodbye world!";
            Console.WriteLine("strA = \"{0}\" strB = \"{1}\"", strA, strB);
            
            Console.WriteLine("After strA changes, ReferenceEquals(strA, strB) = {0}",
                            Object.ReferenceEquals(strA, strB)); // false
            
            // A string that is created at runtime cannot be interned.
            StringBuilder sb = new StringBuilder("Hello world!");
            string stringC = sb.ToString(); 
            // False:
            Console.WriteLine("ReferenceEquals(stringC, strB) = {0}",
                            Object.ReferenceEquals(stringC, strB));

            // The string class overloads the == operator to perform an equality comparison.
            Console.WriteLine("stringC == strB = {0}", stringC == strB); // true

            #endregion

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
     */
}
