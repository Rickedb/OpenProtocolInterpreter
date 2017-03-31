using System;

namespace OpenProtocolInterpreter.MIDs.Reply
{
    /// <summary>
    /// MID: Application Communication positive acknowledge
    /// Description: 
    ///     This message is used by the controller to confirm that the latest command, request or subscription sent
    ///     by the integrator was accepted.The data field contains the MID of the request accepted if the special
    ///     MIDs for request or subscription are used.
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    ///     When using the communication acknowledgement of MID 9997 and MID 9998 together with
    ///     sequence numbering this is an application level message only.
    ///     When using the GENERIC subscription MIDs 0008 and 0009 the data field contains the MID of
    ///     the subscribed MID.
    /// 
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0005 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 24;
        private const int mid = 5;
        private const int revision = 1;

        public int MIDAccepted { get; set; }

        public MID_0005(int midAccepted) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.MIDAccepted = midAccepted;
        }

        public MID_0005(IMID nextTemplate) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            if (this.MIDAccepted == 0)
                throw new ArgumentNullException("MIDAccepted cannot be null");

            return base.buildHeader() + this.MIDAccepted.ToString().PadLeft(4, '0');
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);
                this.MIDAccepted = (int)base.RegisteredDataFields[(int)DataFields.MIDAccepted].Value;
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.MIDAccepted, 20, 4));
        }

        public enum DataFields
        {
            MIDAccepted
        }
    }
}
