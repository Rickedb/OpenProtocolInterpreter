using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Parameter set ID upload reply
    /// Description: 
    ///     The transmission of all the valid parameter set IDs of the controller. In the revision 000-001 the data
    ///     field contains the number of valid parameter sets currently present in the controller, and the ID of each
    ///     parameter set present.In revision 2 is the number of stages on each Pset/Mset added.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0011 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 23;
        private const int mid = 11;
        private const int revision = 1;

        public int TotalParameterSets { get; private set; }

        public List<int> ParameterSets { get; set; }

        public MID_0011() : base(length, mid, revision)
        {
            this.ParameterSets = new List<int>();
        }

        public MID_0011(IEnumerable<int> parameterSets) : base(length, mid, revision)
        {
            this.ParameterSets = parameterSets.ToList();
        }

        public MID_0011(IMID nextTemplate) : base(length, mid, revision)
        {
            this.ParameterSets = new List<int>();
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            if (this.ParameterSets.Count == 0)
                throw new ArgumentException("Parameter Set list cannot be empty!!");

            string package = base.buildHeader();
            package += this.ParameterSets.Count.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.TOTAL_PARAMETER_SETS].Size, '0');

            var datafield = this.RegisteredDataFields[(int)DataFields.EACH_PARAMETER_SET];
            foreach(int param in this.ParameterSets)
                package += param.ToString().PadLeft(datafield.Size, '0');

            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);

                var datafield = this.RegisteredDataFields[(int)DataFields.TOTAL_PARAMETER_SETS];
                this.TotalParameterSets = Convert.ToInt32(package.Substring(datafield.Index, datafield.Size));

                datafield = this.RegisteredDataFields[(int)DataFields.EACH_PARAMETER_SET];
                int packageIndex = datafield.Index;
                for (int i = 0; i < this.TotalParameterSets; i++)
                {
                    this.ParameterSets.Add(Convert.ToInt32(package.Substring(packageIndex, datafield.Size)));
                    packageIndex += datafield.Size;
                }

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.TOTAL_PARAMETER_SETS, 20, 3));
            this.RegisteredDataFields.Add(new DataField((int)DataFields.EACH_PARAMETER_SET, 23, 3));
        }

        public enum DataFields
        {
            TOTAL_PARAMETER_SETS,
            EACH_PARAMETER_SET
        }
    }
}
