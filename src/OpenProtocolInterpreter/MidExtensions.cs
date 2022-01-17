using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Mid Extensions functions
    /// </summary>
    public static class MidExtensions
    {
        /// <summary>
        /// Get RevisionByFields property from Mid
        /// </summary>
        /// <param name="mid">Mid instance</param>
        /// <returns><RevisionByFields dictionary</returns>
        public static IDictionary<int, List<DataField>> GetRevisionByFields(this Mid mid)
        {
            if (mid == default)
            {
                return default;
            }

            return mid.RevisionsByFields;
        }

        /// <summary>
        /// <see cref="Mid.PackBytes"/> then concatenat NUL charactor to it`s end
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
