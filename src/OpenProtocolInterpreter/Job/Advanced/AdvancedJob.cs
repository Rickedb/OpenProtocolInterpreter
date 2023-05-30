using System.Collections.Generic;

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
            var fields = new List<string>
                {
                    OpenProtocolConvert.ToString('0', 2, DataField.PaddingOrientations.LeftPadded, ChannelId),
                    OpenProtocolConvert.ToString('0', 3, DataField.PaddingOrientations.LeftPadded, revision),
                    OpenProtocolConvert.ToString((int)revision),
                    OpenProtocolConvert.ToString('0', 2, DataField.PaddingOrientations.LeftPadded, revision),
                    OpenProtocolConvert.ToString('0', 2, DataField.PaddingOrientations.LeftPadded, revision)
                };

            if (revision > 1)
            {
                fields.Add(OpenProtocolConvert.ToString('0', 2, DataField.PaddingOrientations.LeftPadded, revision));
                if (revision != 999)
                {
                    fields.Add(OpenProtocolConvert.ToString('0', 4, DataField.PaddingOrientations.LeftPadded, revision));
                    fields.Add(OpenProtocolConvert.TruncatePadded(' ', 25, DataField.PaddingOrientations.RightPadded, JobStepName));
                    fields.Add(OpenProtocolConvert.ToString('0', 2, DataField.PaddingOrientations.LeftPadded, revision));
                    if (revision == 3)
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
        {
            var fields = section.Split(':');
            var obj = new AdvancedJob()
            {
                ChannelId = OpenProtocolConvert.ToInt32(fields[0]),
                ProgramId = OpenProtocolConvert.ToInt32(fields[1]),
                AutoSelect = (AutoSelect)OpenProtocolConvert.ToInt32(fields[2]),
                BatchSize = OpenProtocolConvert.ToInt32(fields[3]),
                MaxCoherentNok = OpenProtocolConvert.ToInt32(fields[4])
            };

            if (revision > 1)
            {
                obj.BatchCounter = OpenProtocolConvert.ToInt32(fields[5]);
                if (revision != 999)
                {
                    obj.IdentifierNumber = OpenProtocolConvert.ToInt32(fields[6]);
                    obj.JobStepName = fields[7];
                    obj.JobStepType = OpenProtocolConvert.ToInt32(fields[8]);
                    if (revision == 3)
                    {
                        obj.ToolLoosening = (ToolLoosening)OpenProtocolConvert.ToInt32(fields[9]);
                        obj.JobBatchMode = (BatchMode)OpenProtocolConvert.ToInt32(fields[10]);
                        obj.BatchStatusAtIncrement = (BatchStatusAtIncrement)OpenProtocolConvert.ToInt32(fields[11]);
                        obj.DecrementBatchAfterLoosening = (DecrementBatchAfterLoosening)OpenProtocolConvert.ToInt32(fields[12]);
                        obj.CurrentBatchStatus = (CurrentBatchStatus)OpenProtocolConvert.ToInt32(fields[13]);
                    }
                }
            }

            return obj;
        }

        public static IEnumerable<AdvancedJob> ParseAll(string section, int revision)
        {
            if (string.IsNullOrEmpty(section))
            {
                yield break;
            }

            var splitted = section.Split(';');
            foreach (var advancedJob in splitted)
            {
                yield return Parse(advancedJob, revision);
            }
        }
    }
}
