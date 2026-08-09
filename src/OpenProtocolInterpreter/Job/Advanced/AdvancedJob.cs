using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Represents a advanced job entity
    /// </summary>
    public class AdvancedJob
    {
        public int ChannelId { get; set; }
        public int ProgramId { get; set; }
        public AutoSelect AutoSelect { get; set; }
        public int BatchSize { get; set; }
        public int MaxCoherentNok { get; set; }
        //Rev 2 and Rev 999 for BatchCounter only
        public int BatchCounter { get; set; }
        public int IdentifierNumber { get; set; }
        public string JobStepName { get; set; }
        public int JobStepType { get; set; }
        //Rev 3
        public ToolLoosening ToolLoosening { get; set; }
        public BatchMode JobBatchMode { get; set; }
        public BatchStatusAtIncrement BatchStatusAtIncrement { get; set; }
        public DecrementBatchAfterLoosening DecrementBatchAfterLoosening { get; set; }
        public CurrentBatchStatus CurrentBatchStatus { get; set; }

        public string Pack(int revision)
        {
            var batchSizeFieldSize = revision > 3 && revision != 999 ? 4 : 2;
            var fields = new List<string>
                {
                    OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, ChannelId),
                    OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, ProgramId),
                    OpenProtocolConvert.ToString((int)AutoSelect),
                    OpenProtocolConvert.ToString('0', batchSizeFieldSize, PaddingOrientation.LeftPadded, BatchSize),
                    OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, MaxCoherentNok)
                };

            if (revision > 1)
            {
                fields.Add(OpenProtocolConvert.ToString('0', batchSizeFieldSize, PaddingOrientation.LeftPadded, BatchCounter));
                if (revision != 999)
                {
                    fields.Add(OpenProtocolConvert.ToString('0', 4, PaddingOrientation.LeftPadded, IdentifierNumber));
                    fields.Add(OpenProtocolConvert.TruncatePadded(' ', 25, PaddingOrientation.RightPadded, JobStepName));
                    fields.Add(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, JobStepType));
                    if (revision > 2)
                    {
                        fields.Add(OpenProtocolConvert.ToString((int)ToolLoosening));
                        fields.Add(OpenProtocolConvert.ToString((int)JobBatchMode));
                        fields.Add(OpenProtocolConvert.ToString((int)BatchStatusAtIncrement));
                        fields.Add(OpenProtocolConvert.ToString((int)DecrementBatchAfterLoosening));
                        fields.Add(OpenProtocolConvert.ToString((int)CurrentBatchStatus));
                    }
                }
            }

            return string.Join(":", fields);
        }

        public static AdvancedJob Parse(string section, int revision)
            => Parse(section.AsSpan(), revision);

        public static AdvancedJob Parse(ReadOnlySpan<char> section, int revision)
        {
            var remaining = section;
            var obj = new AdvancedJob()
            {
                ChannelId = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':')),
                ProgramId = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':')),
                AutoSelect = (AutoSelect)OpenProtocolConvert.ToInt32(NextField(ref remaining, ':')),
                BatchSize = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':')),
                MaxCoherentNok = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'))
            };

            if (revision > 1)
            {
                obj.BatchCounter = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                if (revision != 999)
                {
                    obj.IdentifierNumber = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                    obj.JobStepName = NextField(ref remaining, ':').ToString();
                    obj.JobStepType = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                    if (revision > 2)
                    {
                        obj.ToolLoosening = (ToolLoosening)OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                        obj.JobBatchMode = (BatchMode)OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                        obj.BatchStatusAtIncrement = (BatchStatusAtIncrement)OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                        obj.DecrementBatchAfterLoosening = (DecrementBatchAfterLoosening)OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                        obj.CurrentBatchStatus = (CurrentBatchStatus)OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                    }
                }
            }

            return obj;
        }

        public static IEnumerable<AdvancedJob> ParseAll(string section, int revision)
            => ParseAll(section.AsSpan(), revision);

        public static IEnumerable<AdvancedJob> ParseAll(ReadOnlySpan<char> section, int revision)
        {
            if (section.IsEmpty)
                return Array.Empty<AdvancedJob>();

            var result = new List<AdvancedJob>();
            var remaining = section;
            while (!remaining.IsEmpty)
            {
                var job = NextField(ref remaining, ';');
                if (!job.IsWhiteSpace())
                    result.Add(Parse(job, revision));
            }
            return result;
        }

        private static ReadOnlySpan<char> NextField(ref ReadOnlySpan<char> remaining, char separator)
        {
            int idx = remaining.IndexOf(separator);
            if (idx < 0)
            {
                var last = remaining;
                remaining = ReadOnlySpan<char>.Empty;
                return last;
            }

            var field = remaining.Slice(0, idx);
            remaining = remaining.Slice(idx + 1);
            return field;
        }

        internal static int GetDefaultSize(int revision)
        {
            return revision switch
            {
                1 => 15,
                2 => 52,
                3 => 63,
                4 => 67,
                999 => 18,
                _ => 67,
            };
        }
    }

    public class AdvancedJobCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public AdvancedJobCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public AdvancedJobCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<AdvancedJob>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackAdvancedJobs,
                DefaultParser = ParseAdvancedJobs
            }.Bind(owner, propertyInfo);
        }

        private string PackAdvancedJobs(char paddingChar, int size, PaddingOrientation orientation, List<AdvancedJob> advancedJobs)
        {
            var list = new List<string>();
            foreach (var advancedJob in advancedJobs)
                list.Add(advancedJob.Pack(Revision));

            return string.Concat(string.Join(";", list), ";");
        }

        private List<AdvancedJob> ParseAdvancedJobs(string value)
            => AdvancedJob.ParseAll(value, Revision).ToList();
    }
}
