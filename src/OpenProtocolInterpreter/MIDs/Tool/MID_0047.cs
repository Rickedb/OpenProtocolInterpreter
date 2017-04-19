using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Tool
{
    /// <summary>
    /// MID: Tool Pairing handling
    /// Description: 
    ///     This message is sent by the integrator in order to Pair tools, to abort ongoing pairing, 
    ///     to Abort/Disconnect established connection and request for pairing status of the IRC-B or IRC-W tool types.
    ///     At pairing handling type, Start Pairing and Pairing Abort or Disconnect the controller must take program control 
    ///     and release when finished. MID 0048 will be uploaded during the pairing process at each change of the pairing stage.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted at pairing status ACCEPTED
    ///         MID 0004 Command error. See error codes. 
    ///         MID 0048 Pairing status during the pairing process
    /// </summary>
    public class MID_0047 : MID, ITool
    {
        private const int length = 24;
        private const int mid = 47;
        private const int revision = 1;

        public PairingHandlingTypes PairingHandlingType { get; set; }

        public MID_0047() : base(length, mid, revision)
        {
            this.registerDatafields();
        }

        public MID_0047(IMID nextTemplate) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.PAIRING_HANDLING_TYPE, 20, 2));

        }

        public enum PairingHandlingTypes
        {
            START_PAIRING = 01,
            PAIRING_ABORT_OR_DISCONNECT = 02,
            FETCH_LATEST_PAIRING_STATUS = 03
        }

        public enum DataFields
        {
            PAIRING_HANDLING_TYPE
        }
    }
}
