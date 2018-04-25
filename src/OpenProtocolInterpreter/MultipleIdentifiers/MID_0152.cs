using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifier and result parts
    /// Description: 
    ///    Transmission of the work order status, optional identifier and identifier result parts
    ///    by the controller to the subscriber.
    ///    
    ///    The identifier contains the status of the maximum four identifier result parts that could 
    ///    be extracted from one or more valid identifiers.
    /// Message sent by: Controller
    /// Answer: MID 0153 Multiple identifiers and result parts acknowledge
    /// </summary>
    public class MID_0152 : Mid, IMultipleIdentifier
    {
        public const int MID = 152;
        private const int length = 150;
        private const int revision = 1;

        public IdentifierStatus FirstIdentifierStatus { get; set; }
        public IdentifierStatus SecondIdentifierStatus { get; set; }
        public IdentifierStatus ThirdIdentifierStatus { get; set; }
        public IdentifierStatus FourthIdentifierStatus { get; set; }

        public MID_0152() : base(length, MID, revision) { }

        internal MID_0152(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            base.RegisteredDataFields[(int)DataFields.FIRST_IDENTIFIER_STATUS].Value = FirstIdentifierStatus.buildPackage();
            base.RegisteredDataFields[(int)DataFields.SECOND_IDENTIFIER_STATUS].Value = SecondIdentifierStatus.buildPackage();
            base.RegisteredDataFields[(int)DataFields.THIRD_IDENTIFIER_STATUS].Value = ThirdIdentifierStatus.buildPackage();
            base.RegisteredDataFields[(int)DataFields.FOURTH_IDENTIFIER_STATUS].Value = FourthIdentifierStatus.buildPackage();
            return base.BuildPackage();
        }
        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                ProcessPackage(package);

                FirstIdentifierStatus = new IdentifierStatus().getIdentifierStatusFromPackage(base.RegisteredDataFields[(int)DataFields.FIRST_IDENTIFIER_STATUS].Value.ToString());
                SecondIdentifierStatus = new IdentifierStatus().getIdentifierStatusFromPackage(base.RegisteredDataFields[(int)DataFields.SECOND_IDENTIFIER_STATUS].Value.ToString());
                ThirdIdentifierStatus = new IdentifierStatus().getIdentifierStatusFromPackage(base.RegisteredDataFields[(int)DataFields.THIRD_IDENTIFIER_STATUS].Value.ToString());
                FourthIdentifierStatus = new IdentifierStatus().getIdentifierStatusFromPackage(base.RegisteredDataFields[(int)DataFields.FOURTH_IDENTIFIER_STATUS].Value.ToString());

                return this;
            }

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(new DataField[]
                {
                            new DataField((int)DataFields.FIRST_IDENTIFIER_STATUS, 20, 30),
                            new DataField((int)DataFields.SECOND_IDENTIFIER_STATUS, 52, 30),
                            new DataField((int)DataFields.THIRD_IDENTIFIER_STATUS, 84, 30),
                            new DataField((int)DataFields.FOURTH_IDENTIFIER_STATUS, 116, 30)
                });
        }

        public enum DataFields
        {
            FIRST_IDENTIFIER_STATUS,
            SECOND_IDENTIFIER_STATUS,
            THIRD_IDENTIFIER_STATUS,
            FOURTH_IDENTIFIER_STATUS
        }

        public class IdentifierStatus
        {
            private List<DataField> fields;
            public int IdentifierTypeNumber { get; set; }
            public bool IncludedInWorkOrder { get; set; }
            public StatusesInWorkOrder StatusInWorkOrder { get; set; }
            public string ResultPart { get; set; }

            public IdentifierStatus()
            {
                fields = new List<DataField>();
                registerDatafields();
            }

            public string buildPackage()
            {
                string pkg = string.Empty;
                pkg += IdentifierTypeNumber.ToString();
                pkg += Convert.ToInt32(IncludedInWorkOrder).ToString().PadLeft(2, '0');
                pkg += ((int)StatusInWorkOrder).ToString().PadLeft(2, '0');
                pkg += ResultPart.ToString();
                return pkg;
            }

            public IdentifierStatus getIdentifierStatusFromPackage(string package)
            {
                processPackage(package);
                IdentifierStatus obj = new IdentifierStatus();

                obj.IdentifierTypeNumber = fields[(int)DataFields.IDENTIFIER_TYPE_NUMBER].ToInt32();
                obj.IncludedInWorkOrder = fields[(int)DataFields.INCLUDED_IN_WORK_ORDER].ToBoolean();
                obj.StatusInWorkOrder = (StatusesInWorkOrder)fields[(int)DataFields.STATUS_IN_WORK_ORDER].ToInt32();
                obj.ResultPart = fields[(int)DataFields.RESULT_PART].Value.ToString();

                return obj;
            }

            private void processPackage(string package)
            {
                foreach (var field in fields)
                    field.Value = package.Substring(field.Index, field.Size);
            }

            private void registerDatafields()
            {
                fields.AddRange(
                    new DataField[]
                    {
                            new DataField((int)DataFields.IDENTIFIER_TYPE_NUMBER, 0, 1),
                            new DataField((int)DataFields.INCLUDED_IN_WORK_ORDER, 1, 2),
                            new DataField((int)DataFields.STATUS_IN_WORK_ORDER, 3, 2),
                            new DataField((int)DataFields.RESULT_PART, 5, 25)
                    });
            }

            public enum StatusesInWorkOrder
            {
                NOT_ACCEPTED = 0,
                ACCEPTED = 1,
                BYPASSED = 2,
                RESET = 3,
                NEXT = 4,
                INITIAL = 5
            }

            public enum DataFields
            {
                IDENTIFIER_TYPE_NUMBER,
                INCLUDED_IN_WORK_ORDER,
                STATUS_IN_WORK_ORDER,
                RESULT_PART
            }
        }
    }
}
