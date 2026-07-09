using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector control green lights
    /// <para>
    ///     This message controls the selector green lights.
    ///     The green light can be set (steady), reset (off) or flash.
    ///     A command must be sent for each one of the selector positions (1-8).
    /// </para>
    /// <para>
    ///     Note: This MID only works when the selector is put in external controlled mode and
    ///     this is only possible when the selector is loaded with software 1.20 or later.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Faulty IO device ID</para>
    /// </summary>
    public class Mid0254 : Mid, IApplicationSelector, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 254;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.FaultyIODeviceId };

        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 2)]
        public int DeviceId { get; set; }

        [EnumCollectionDefinition<LightCommand>(field: 2, revision: 1, Size = 8)]
        public List<LightCommand> GreenLights { get; set; }

        public Mid0254() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0254(Header header) : base(header)
        {
            GreenLights ??= [];
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            DeviceId,
            GreenLightCommand
        }
    }
}
