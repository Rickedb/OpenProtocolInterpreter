using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.LinkCommunication
{
    /// <summary>
    /// MID: Communication acknowledge error
    /// Description: 
    ///     This message is used in conjunction with the use of header sequence number.
    /// Message sent by: Controller and Integrator:
    ///     This message is sent immediately after the message is received on application link level and if the check of the header is found to be wrong in any way.
    ///     The acknowledge substitute the use of NoAck flag and all subscription data special acknowledging.
    /// </summary>
    class MID_9998 : MID
    {
        private const int length = 27;
        public const int MID = 9998;
        private const int revision = 1;

        public MID_9998() : base(length, MID, revision, null, null, null, new DataField[]
        {
            new DataField((int)UsedsAs.MESSAGE_NUMBER, 16, 2),
            new DataField((int)UsedsAs.NUMBER_OF_MESSAGES, 18, 1),
            new DataField((int)UsedsAs.SEQUENCE_NUMBER, 19, 1)
        })
        {

        }

        internal MID_9998(IMID nextTemplate) : base(length, MID, revision, null, null, null, new DataField[] 
        {
            new DataField((int)UsedsAs.MESSAGE_NUMBER, 16, 2),
            new DataField((int)UsedsAs.NUMBER_OF_MESSAGES, 18, 1),
            new DataField((int)UsedsAs.SEQUENCE_NUMBER, 19, 1)
        })
        {
            this.NextTemplate = nextTemplate;
            
        }

        protected override string BuildHeader()
        {
            string header = string.Empty;
            header += this.HeaderData.Length.ToString().PadLeft(4, '0');
            header += this.HeaderData.Mid.ToString().PadLeft(4, '0');
            header += this.HeaderData.Revision.ToString().PadLeft(3, '0');
            header += this.HeaderData.NoAckFlag.ToString().PadLeft(1, ' ');
            header += (this.HeaderData.StationID != null) ? this.HeaderData.StationID.ToString().PadLeft(2, '0') : this.HeaderData.StationID.ToString().PadLeft(2, ' ');
            header += (this.HeaderData.SpindleID != null) ? this.HeaderData.SpindleID.ToString().PadLeft(2, '0') : this.HeaderData.SpindleID.ToString().PadLeft(2, ' ');
            string usedAs = "    ";
            if (this.HeaderData.UsedAs != null)
            {
                usedAs = string.Empty;
                foreach (DataField field in this.HeaderData.UsedAs)
                    usedAs += field.Value.ToString().PadLeft(field.Size, ' ');
            }
            header += usedAs;
            return header;
        }

        protected override Header ProcessHeader(string package)
        {
            Header header = base.ProcessHeader(package);

            header.UsedAs.ToList()[(int)UsedsAs.MESSAGE_NUMBER].Value = (!string.IsNullOrWhiteSpace(package.Substring(16, 2))) ? package.Substring(16, 2) : null;
            header.UsedAs.ToList()[(int)UsedsAs.NUMBER_OF_MESSAGES].Value = (!string.IsNullOrWhiteSpace(package.Substring(18, 1))) ? package.Substring(18, 1) : null;
            header.UsedAs.ToList()[(int)UsedsAs.SEQUENCE_NUMBER].Value = (!string.IsNullOrWhiteSpace(package.Substring(19, 1))) ? package.Substring(19, 1) : null;

            return header;
        }

        public override string BuildPackage()
        {
            return base.BuildPackage();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.ProcessHeader(package);

            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }

        public enum UsedsAs
        {
            SEQUENCE_NUMBER,
            NUMBER_OF_MESSAGES,
            MESSAGE_NUMBER
        }

        public enum ErroCodes
        {
            INVALID_LENGTH = 1,
            INVALID_REVISION = 2,
            INVALID_SEQUENCE_NUMBER = 3,
            INCONSISTENCY_OF_NUMBER_OF_MESSAGES = 4
        }
    }
}
