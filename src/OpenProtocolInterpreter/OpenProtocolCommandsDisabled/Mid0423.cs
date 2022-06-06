﻿namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// Open Protocol commands disabled unsubscribe
    /// <para>Reset the subscription for the Open Protocol commands disabled digital input.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///         <see cref="Communication.Mid0004"/> Command error, Open Protocol commands disabled
    ///         subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0423 : Mid, IOpenProtocolCommandsDisabled, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 423;

        public Mid0423() : base(MID, LAST_REVISION) { }

        public Mid0423(Header header) : base(header)
        {
        }
    }
}
