using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// MID: Last Power MACS tightening result data acknowledge
    /// Description: 
    ///    If Bolt Data is set to TRUE the next telegram with Bolt data is sent (if there are any left for this
    ///    tightening). Otherwise no more Bolt data is sent for this tightening.
    ///    If only the station data is wanted Bolt Data must be set to FALSE in the acknowledgement of MID 0106
    ///    Last Power MACS tightening result Station data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0108 : Mid, IPowerMACS
    {
        public const int MID = 108;
        private const int length = 21;
        private const int revision = 1;

        public bool BoltData { get; set; }

        public MID_0108() : base(length, MID, revision) { }

        internal MID_0108(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + Convert.ToInt32(BoltData).ToString();
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.BOLT_DATA];
                BoltData = Convert.ToBoolean(Convert.ToInt32(package.Substring(dataField.Index, dataField.Size)));
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.BOLT_DATA, 20, 1));
        }

        public enum DataFields
        {
            BOLT_DATA
        }
    }
}
