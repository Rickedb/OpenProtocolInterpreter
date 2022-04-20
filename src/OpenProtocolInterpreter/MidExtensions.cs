using System.Linq;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Mid Extensions functions
    /// </summary>
    public static class MidExtensions
    {
        /// <summary>
        /// <see cref="Mid.Pack"/> then concatenate NUL charactor to it`s end
        /// </summary>
        /// <param name="mid">Mid instance</param>
        /// <returns>Mid's package in string with NUL character</returns>
        public static string PackWithNul(this Mid mid)
        {
            if (mid == default)
            {
                return default;
            }

            var value = mid.Pack();
            return string.Concat(value, '\0');
        }

        /// <summary>
        /// <see cref="Mid.PackBytes"/> then concatenate NUL charactor to it`s end
        /// </summary>
        /// <param name="mid">Mid instance</param>
        /// <returns>Mid's package in bytes with NUL character</returns>
        public static byte[] PackBytesWithNul(this Mid mid)
        {
            if (mid == default)
            {
                return default;
            }

            var bytes = mid.PackBytes();
            return bytes.Concat(new byte[] { 0x00 }).ToArray();
        }
    }
}
