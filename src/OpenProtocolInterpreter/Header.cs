using System.Text;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Represents a Mid header
    /// </summary>
    public sealed class Header
    {
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
            Length = 20; //default length
        }

        public override string ToString()
        {
            StringBuilder header = new StringBuilder();
            header.Append(Length.ToString($"D{4}"));
            header.Append(Mid.ToString($"D{4}"));
            header.Append((Revision > 0)? Revision.ToString($"D{3}"): "   ");
            header.Append(NoAckFlag ? "1" : " ");
            header.Append((StationId != null) ? ((int)StationId).ToString($"D{2}") : "  ");
            header.Append((SpindleId != null) ? ((int)SpindleId).ToString($"D{2}") : "  ");
            header.Append((SequenceNumber != null) ? ((int)SequenceNumber).ToString($"D{2}") : "  ");
            header.Append((NumberOfMessages != null) ? ((int)NumberOfMessages ).ToString() : " ");
            header.Append((MessageNumber != null) ? ((int)MessageNumber ).ToString() : " ");
            return header.ToString();
        }
    }
}

