namespace NullableDemo
{
    public class NullableUsage
    {
        public void Sample()
        {
            int? i = null;
            i++;

            int? i2 = 325;
            i2++;

            int? n = i2 * 2;
            int result = ((System.IComparable)n).CompareTo(325);
            int result2 = ((System.IComparable)(int)n).CompareTo(325);
        }
    }
}
