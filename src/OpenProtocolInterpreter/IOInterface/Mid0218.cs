﻿namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Relay function acknowledge
    /// <para>Acknowledgement of relay function upload.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0218 : Mid, IIOInterface, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 218;

        public Mid0218() : base(MID, LAST_REVISION) { }

        public Mid0218(Header header) : base(header)
        {
        }
    }
}
