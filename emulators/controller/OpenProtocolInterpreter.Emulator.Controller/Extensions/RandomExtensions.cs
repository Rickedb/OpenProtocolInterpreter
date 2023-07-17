namespace System
{
    internal static class RandomExtensions
    {
        public static bool NextBoolean(this Random random)
        {
            var value = random.Next(0, 1);
            return value != 0;
        }
    }
}
