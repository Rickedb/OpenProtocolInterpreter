using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace OpenProtocolInterpreter.Converters
{
    public class ParameterSetListConverter : AsciiConverter<IEnumerable<Job.ParameterSet>>
    {
        private readonly int _revision;
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;

        public ParameterSetListConverter(IValueConverter<int> intConverter, IValueConverter<bool> boolConverter, int revision)
        {
            _revision = revision;
            _intConverter = intConverter;
            _boolConverter = boolConverter;
        }

        public override IEnumerable<Job.ParameterSet> Convert(string value)
        {
            var psets = new List<Job.ParameterSet>();
            if (!string.IsNullOrWhiteSpace(value))
            {
                var parameterSets = value.Split(';').ToList();
                parameterSets.RemoveAt(parameterSets.Count - 1); //remove last one which will be empty
                foreach (string psetData in parameterSets)
                {
                    string[] fields = psetData.Split(':');
                    var pset = new Job.ParameterSet()
                    {
                        ChannelId = _intConverter.Convert(fields[0]),
                        TypeId = _intConverter.Convert(fields[1]),
                        AutoValue = _boolConverter.Convert(fields[2]),
                        BatchSize = _intConverter.Convert(fields[3])
                    };

                    if (_revision > 2)
                    {
                        pset.JobStepName = fields[5];
                        pset.JobStepType = _intConverter.Convert(fields[6]);

                        if (_revision > 3)
                        {
                            pset.IdentifierNumber = _intConverter.Convert(fields[4]);
                            pset.MaxCoherentNok = _intConverter.Convert(fields[7]);
                        }
                        else
                        {
                            pset.Socket = _intConverter.Convert(fields[4]);
                        }
                    }

                    psets.Add(pset);
                }
            }
            return psets;
        }

        public override string Convert(IEnumerable<Job.ParameterSet> value)
        {
            if (!value.Any())
            {
                return string.Empty;
            }

            var packages = new List<string>();
            foreach (var pset in value)
            {
                var eachPset = new List<string>()
               {
                   _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, pset.ChannelId),
                   _intConverter.Convert('0', 3, DataField.PaddingOrientations.LEFT_PADDED, pset.TypeId),
                   _boolConverter.Convert(pset.AutoValue),
                   _intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, pset.BatchSize)
               };

                if (_revision > 2)
                {
                    if (_revision > 3)
                        eachPset.Add(_intConverter.Convert('0', 4, DataField.PaddingOrientations.LEFT_PADDED, pset.IdentifierNumber));
                    else
                        eachPset.Add(_intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, pset.Socket));

                    eachPset.Add(pset.JobStepName.PadRight(25));
                    eachPset.Add(_intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, pset.JobStepType));

                    if(_revision > 3)
                    {
                        eachPset.Add(_intConverter.Convert('0', 2, DataField.PaddingOrientations.LEFT_PADDED, pset.MaxCoherentNok));
                    }
                }

                packages.Add(string.Join(":", eachPset));
            }

            return string.Join(";", packages) + ";";
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<Job.ParameterSet> value)
        {
            return Convert(value);
        }
    }
}
