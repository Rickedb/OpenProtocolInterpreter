using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set ID upload reply
    /// <para>
    ///     The transmission of all the valid parameter set IDs of the controller. In the revision 000-001 the data
    ///     field contains the number of valid parameter sets currently present in the controller, and the ID of each
    ///     parameter set present.In revision 2 is the number of stages on each Pset/Mset added.
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0011 : Mid, IParameterSet, IController
    {
        public const int MID = 11;

        public int TotalParameterSets
        {
            get => ParameterSets.Count;
        }

        public List<int> ParameterSets { get; set; }

        public Mid0011() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0011(Header header) : base(header)
        {
            if (ParameterSets == null)
                ParameterSets = new List<int>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.TotalParameterSets).SetValue(OpenProtocolConvert.ToString, TotalParameterSets);
            var eachParameterField = GetField(1, (int)DataFields.EachParameterSet);
            eachParameterField.Value = PackParameterSetIdList();
            eachParameterField.Size = eachParameterField.Value.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            GetField(1, (int)DataFields.EachParameterSet).Size = Header.Length - GetField(1, (int)DataFields.EachParameterSet).Index;
            ProcessDataFields(package);
            ParameterSets = ParseParameterSetIdList(GetField(1, (int)DataFields.EachParameterSet).Value).ToList();
            return this;
        }

        protected virtual string PackParameterSetIdList()
        {
            string pack = string.Empty;
            foreach (var v in ParameterSets)
                pack += OpenProtocolConvert.ToString('0', 3, DataField.PaddingOrientations.LeftPadded, v);
            return pack;
        }

        protected virtual List<int> ParseParameterSetIdList(string section)
        {
            var list = new List<int>();
            for (int i = 0; i < section.Length; i += 3)
                list.Add(OpenProtocolConvert.ToInt32(section.Substring(i, 3)));

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TotalParameterSets, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.EachParameterSet, 23, 3, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            TotalParameterSets,
            EachParameterSet
        }
    }
}
