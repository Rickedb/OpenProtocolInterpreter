using OpenProtocolInterpreter.Job.Advanced;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    public class AdvancedJobListConverter : AsciiConverter<IEnumerable<AdvancedJob>>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly int _revision;

        public AdvancedJobListConverter(IValueConverter<int> intConverter, int revision)
        {
            _intConverter = intConverter;
            _revision = revision;
        }

        public override string Convert(IEnumerable<AdvancedJob> value)
        {
            var advancedJobsList = new List<string>();

            foreach (var job in value)
            {
                var fields = new List<string>
                {
                    _intConverter.Convert('0', 2, DataField.PaddingOrientations.LeftPadded, job.ChannelId),
                    _intConverter.Convert('0', 3, DataField.PaddingOrientations.LeftPadded, job.ProgramId),
                    _intConverter.Convert((int)job.AutoSelect),
                    _intConverter.Convert('0', 2, DataField.PaddingOrientations.LeftPadded, job.BatchSize),
                    _intConverter.Convert('0', 2, DataField.PaddingOrientations.LeftPadded, job.MaxCoherentNok)
                };

                if (_revision > 1)
                {
                    fields.Add(_intConverter.Convert('0', 2, DataField.PaddingOrientations.LeftPadded, job.BatchCounter));
                    if (_revision != 999)
                    {
                        fields.Add(_intConverter.Convert('0', 4, DataField.PaddingOrientations.LeftPadded, job.IdentifierNumber));
                        fields.Add(GetTruncatePadded(' ', 25, DataField.PaddingOrientations.RightPadded, job.JobStepName));
                        fields.Add(_intConverter.Convert('0', 2, DataField.PaddingOrientations.LeftPadded, job.JobStepType));
                        if (_revision == 3)
                        {
                            fields.Add(_intConverter.Convert((int)job.ToolLoosening));
                            fields.Add(_intConverter.Convert((int)job.JobBatchMode));
                            fields.Add(_intConverter.Convert((int)job.BatchStatusAtIncrement));
                            fields.Add(_intConverter.Convert((int)job.DecrementBatchAfterLoosening));
                            fields.Add(_intConverter.Convert((int)job.CurrentBatchStatus));
                        }
                    }
                }
                advancedJobsList.Add(string.Join(":", fields));
            }

            return string.Join(";", advancedJobsList);
        }

        public override string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<AdvancedJob> value) => Convert(value);

        public override IEnumerable<AdvancedJob> Convert(string value)
        {
            var list = value.Split(';');
            foreach (var advancedJob in list)
            {
                var fields = advancedJob.Split(':');
                var obj = new AdvancedJob()
                {
                    ChannelId = _intConverter.Convert(fields[0]),
                    ProgramId = _intConverter.Convert(fields[1]),
                    AutoSelect = (AutoSelect)_intConverter.Convert(fields[2]),
                    BatchSize = _intConverter.Convert(fields[3]),
                    MaxCoherentNok = _intConverter.Convert(fields[4])
                };

                if (_revision > 1)
                {
                    obj.BatchCounter = _intConverter.Convert(fields[5]);
                    if (_revision != 999)
                    {
                        obj.IdentifierNumber = _intConverter.Convert(fields[6]);
                        obj.JobStepName = fields[7];
                        obj.JobStepType = _intConverter.Convert(fields[8]);
                        if (_revision == 3)
                        {
                            obj.ToolLoosening = (ToolLoosening)_intConverter.Convert(fields[9]);
                            obj.JobBatchMode = (BatchMode)_intConverter.Convert(fields[10]);
                            obj.BatchStatusAtIncrement = (BatchStatusAtIncrement)_intConverter.Convert(fields[11]);
                            obj.DecrementBatchAfterLoosening = (DecrementBatchAfterLoosening)_intConverter.Convert(fields[12]);
                            obj.CurrentBatchStatus = (CurrentBatchStatus)_intConverter.Convert(fields[13]);
                        }
                    }
                }

                yield return obj;
            }
        }
    }
}
