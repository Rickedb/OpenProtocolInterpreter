﻿namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Last tightening result data acknowledge
    /// <para>Acknowledgement of last tightening result data.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0062 : Mid, ITightening, IIntegrator
    {
        private const int LAST_REVISION = 6;
        public const int MID = 62;

        public Mid0062() : this(LAST_REVISION)
        {

        }

        public Mid0062(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        public Mid0062(Header header) : base(header)
        {
        }
    }
}
