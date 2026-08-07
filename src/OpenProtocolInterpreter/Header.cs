using System;
using System.Text;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Represents a Mid header
    /// </summary>
    public sealed class Header
    {
        public const int DefaultSize = 20;

        /// <summary>
        /// Length of the header plus the data field excluding the NUL termination.
        /// </summary>
        public int Length { get; internal set; }

        /// <summary>
        /// The MID describes how to interpret the message
        /// </summary>
        public int Mid { get; set; }

        /// <summary>
        /// The MID Revision is unique per MID and is used in case different versions are available for the same MID.
        /// Using the revision number the integrator can subscribe or ask for different versions of the same MID.
        /// <para>
        ///     Note: The default MID Revision is 1. There is three different ways to get it, either send three spaces or 000 or 001.
        /// </para>
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// The MID Revision is unique per MID and is used in case different versions are available for the same MID.
        /// Using the revision number the integrator can subscribe or ask for different versions of the same MID.
        /// <para>
        ///     Note: Enforces the default MID Revision to 1 when it's either send three spaces or 000 or 001.
        /// </para>
        /// </summary>
        public int StandardizedRevision => Revision > 0 ? Revision : 1;

        /// <summary>
        /// Define if subscriber will acknowledge each "push" message sent by controller (reliable mode) or just push without waiting for a receive acknowledgement from subscriber (unreliable mode)
        /// <para>Notes:</para>
        /// <list type="number">
        ///     <item>Works only for subscription Mids</item>
        ///     <item>Not used when using sequence number handling</item>
        /// </list>
        /// </summary>
        public bool NoAckFlag { get; set; }

        /// <summary>
        /// The station the message is addressed to in the case of controller with multi-station configuration.
        /// <para>Note: Two spaces are considered as station 1</para>
        /// </summary>
        public int? StationId { get; set; }
        /// <summary>
        /// The spindle the message is addressed to in the case several spindles are connected to the same controller.
        /// <para>Note: Two spaces are considered as spindle 1</para>
        /// </summary>
        public int? SpindleId { get; set; }

        /// <summary>
        /// For acknowledging on "Link Level" with MIDs 0997 and 0998.
        /// <para>Note: Not used if space or zero</para>
        /// </summary>
        public int? SequenceNumber { get; set; }

        /// <summary>
        /// Linking function can be 1 to 9 (possible to send 9*9999 bytes messages).
        /// <para>Used when the message length is overflowing the max length of 9999.</para>
        /// <para>Note: Not used if space or zero.</para>
        /// </summary>
        public int? NumberOfMessages { get; set; }

        /// <summary>
        /// Linking function, can be 1 to 9 at message length > 9999.
        /// <para>Note: Not used if space or zero</para>
        /// </summary>
        public int? MessageNumber { get; set; }

        public Header()
        {
            Length = DefaultSize; //default length
        }

        public void EnforceRevisionStandardization()
            => Revision = StandardizedRevision;

        public override string ToString()
        {
            var builder = new StringBuilder(Length.ToString("D4"));
            builder.Append(Mid.ToString("D4"));
            builder.Append((Revision > 0) ? Revision.ToString("D3") : "   ");
            builder.Append(NoAckFlag ? "1" : " ");
            builder.Append(StationId.HasValue ? StationId.Value.ToString("D2") : "  ");
            builder.Append(SpindleId.HasValue ? SpindleId.Value.ToString("D2") : "  ");
            builder.Append(SequenceNumber.HasValue ? SequenceNumber.Value.ToString("D2") : "  ");
            builder.Append(NumberOfMessages.HasValue ? NumberOfMessages.ToString() : " ");
            builder.Append(MessageNumber.HasValue ? MessageNumber.ToString() : " ");
            return builder.ToString();
        }

        /// <summary>
        /// Parses the header from a string representation of the MID message.
        /// </summary>
        /// <param name="package">The MID message as a string.</param>
        /// <returns>The parsed <see cref="Header"/> object.</returns>
        public static Header Parse(string package)
            => Parse(package.AsSpan());

        /// <summary>
        /// Parses the header from a read-only span of characters representing the MID message.
        /// </summary>
        /// <param name="package">The MID message as a read-only span of characters.</param>
        /// <returns>The parsed <see cref="Header"/> object.</returns>
        public static Header Parse(ReadOnlySpan<char> package)
        {
#if NETSTANDARD2_0
            static bool IsNotEmptyOrZero(ReadOnlySpan<char> package, out int value)
            {
                value = 0;
                return !package.IsWhiteSpace() && int.TryParse(package.ToString(), out value) && value > 0;
            }
            static int ParseInt(ReadOnlySpan<char> span) => int.Parse(span.ToString());
            static bool TryParseInt(ReadOnlySpan<char> span, out int value) => int.TryParse(span.ToString(), out value);
#else
            static bool IsNotEmptyOrZero(ReadOnlySpan<char> package, out int value)
            {
                value = 0;
                return !package.IsWhiteSpace() && int.TryParse(package, out value) && value > 0;
            }
            static int ParseInt(ReadOnlySpan<char> span) => int.Parse(span);
            static bool TryParseInt(ReadOnlySpan<char> span, out int value) => int.TryParse(span, out value);
#endif

            return new Header
            {
                Length = ParseInt(package.Slice(0, 4)),
                Mid = ParseInt(package.Slice(4, 4)),
                Revision = IsNotEmptyOrZero(package.Slice(8, 3), out var revision) ? revision : 1,
                NoAckFlag = !package.Slice(11, 1).IsWhiteSpace(),
                StationId = TryParseInt(package.Slice(12, 2), out var stationId) ? stationId : 1,
                SpindleId = TryParseInt(package.Slice(14, 2), out var spindleId) ? spindleId : 1,
                SequenceNumber = IsNotEmptyOrZero(package.Slice(16, 2), out var sequenceNumber) ? sequenceNumber : default(int?),
                NumberOfMessages = IsNotEmptyOrZero(package.Slice(18, 1), out var numberOfMessages) ? numberOfMessages : default(int?),
                MessageNumber = IsNotEmptyOrZero(package.Slice(19, 1), out var messageNumber) ? messageNumber : default(int?)
            };
        }
    }
}

