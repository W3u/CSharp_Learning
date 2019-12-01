# Equality And Identity

**Equality: also known as Value Equality**\
**Identity: also known as Reference Equality**

There are 4 approaches to compare objects in C#.
- obj1.Equals(obj2)
- Object.Equals(obj1, obj2)
- operator ==
- Object.ReferenceEquals(obj1, obj2)


Type Category | obj1.Equals(obj2) | Object.Equals(obj1, obj2) | operator == | Object.ReferenceEquals(obj1, obj2)
------------ | ------------- | ------------ | ------------ | ------------
Class derived directly from System.Object(Default Implementation) | Reference Equality | Reference Equality | Reference Equality | Reference Equality
Struct(ValueType override/overload some virtual methods) | Value Equality | Value Equality | Value Equality | Reference Equality


References:
1. [Equality comparisons](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons)
2. [How to: define value equality for a type](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type)
3. [How to: Test for Reference Equality (Identity)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-test-for-reference-equality-identity)
4. [Equality operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators)
