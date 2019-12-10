# GetHashCode

**This project covers:**
1. Why is it important to override GetHashCode when Equals method is overridden?
2. What is the best algorithm for overriding GetHashCode?
	- The algorithm should provide a good random distribution.
	- The fields we use in GetHashCode should be immutable.
	- If you override the GetHashCode method, you should also override Equals, and vice versa. If your overridden Equals method returns true when two objects are tested for equality, your overridden GetHashCode method must return the same value for the two objects.

**We need to override the GetHashCode method when:**
1. Defining a customized value type(the default implementation is using the Reflection mechanism, which results in poor performance)
2. The Equals method is overridden



**References:**
1. [Why need to override GetHashCode when the Equals method is overridden](https://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/)
2. [Why is it important to override GetHashCode when Equals method is overridden?](https://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden)
3. [What is the best algorithm for overriding GetHashCode?](https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode)
4. [Guidelines and rules for GetHashCode](https://blogs.msdn.microsoft.com/ericlippert/2011/02/28/guidelines-and-rules-for-gethashcode/)