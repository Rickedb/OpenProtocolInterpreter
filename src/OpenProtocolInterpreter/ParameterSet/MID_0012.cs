using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set data upload request
    /// Description: 
    ///     Request to upload parameter set data from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0013 Parameter set data upload reply, or MID 0004 Command error, Parameter set not present
    /// </summary>
    public class MID_0012 : MID, IParameterSet
    {
        private readonly Dictionary<int, Action<string>> revisionsActions;
        private readonly Dictionary<int, Func<string>> revisionsBuildActions;
        private const int length = 23;
        public const int MID = 12;
        private const int lastRevision = 2;

        public int ParameterSetID { get; set; }
        public int ParameterSetFileVersion { get; set; }

        public MID_0012(int revision = lastRevision) : base(length, MID, revision) { }

        public MID_0012(int parameterSetId, int revision = lastRevision) : base(length, MID, revision)
        {
            this.ParameterSetID = parameterSetId;
        }

        internal MID_0012(IMID nextTemplate) : base(length, MID, lastRevision)
        {
            this.NextTemplate = nextTemplate;
            this.revisionsActions = new Dictionary<int, Action<string>>()
            {
                { 1, this.processRevision1 },
                { 2, this.processRevision2 }
            };
        }

        public override string BuildPackage()
        {
            string pack = base.BuildHeader();
            for(int i = 1; i < this.HeaderData.Revision; i++)
                pack += this.revisionsBuildActions[i].Invoke();
            return pack;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.UpdateRevisionFromPackage(package);
                this.HeaderData = base.ProcessHeader(package);
                for (int i = 1; i <= this.HeaderData.Revision; i++)
                    this.revisionsActions[i](package);

                return this;
            }
                
            return this.NextTemplate.ProcessPackage(package);
        }

        private void processRevision1(string package)
        {
            var datafield = this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID];
            this.ParameterSetID = Convert.ToInt32(package.Substring(datafield.Index, datafield.Size));
        }

        private void processRevision2(string package)
        {
            var datafield = this.RegisteredDataFields[(int)DataFields.PSET_FILE_VERSION];
            this.ParameterSetID = Convert.ToInt32(package.Substring(datafield.Index, datafield.Size));
        }

        private string buildRevision1(string package = "")
        {
            return this.ParameterSetID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size, '0');
        }

        private string buildRevision2(string package = "")
        {
            return this.ParameterSetFileVersion.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.PSET_FILE_VERSION].Size, '0');
        }

        protected override void RegisterDatafields() 
        {
            this.RevisionsByFields = new Dictionary<int, IEnumerable<DataField>>()
            {
                {
                    1, new DataField[]
                            {
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0')
                            }
                },
                {
                    2, new DataField []
                            {
                                new DataField((int)DataFields.PSET_FILE_VERSION, 24, 8, '0')
                            }
                }
            };
        }

        public enum DataFields
        {
            //Revision 1
            PARAMETER_SET_ID,
            //Revision 2
            PSET_FILE_VERSION
        }
    }
}
