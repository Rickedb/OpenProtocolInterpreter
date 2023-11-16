using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Parameter set entity.
    /// </summary>
    public class ParameterSet
    {
        public int ChannelId { get; set; }
        public int TypeId { get; set; }
        public bool AutoValue { get; set; }
        public int BatchSize { get; set; }
        public int IdentifierNumber { get; set; }
        [Obsolete("Socket is replaced by IdentifierNumber when revision 4 or later")]
        public int Socket { get; set; }
        public string JobStepName { get; set; }
        public int JobStepType { get; set; }
        public int MaxCoherentNok { get; set; }

        public string Pack(int revision)
        {
            var values = new List<string>()
            {
                OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, ChannelId),
                OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, TypeId),
                OpenProtocolConvert.ToString(AutoValue),
                OpenProtocolConvert.ToString('0', revision > 4 ? 4 : 2, PaddingOrientation.LeftPadded, BatchSize)
            };

            if (revision > 2)
            {
                if (revision == 3)
                {
                    values.Add(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, Socket));
                }
                else
                {
                    values.Add(OpenProtocolConvert.ToString('0', 4, PaddingOrientation.LeftPadded, IdentifierNumber));
                }

                values.Add(JobStepName.PadRight(25));
                values.Add(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, JobStepType));

                if (revision > 3)
                {
                    values.Add(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, MaxCoherentNok));
                }
            }

            return string.Join(":", values);
        }

        public static ParameterSet Parse(string section, int revision)
        {
            string[] fields = section.Split(':');
            var pset = new ParameterSet()
            {
                ChannelId = OpenProtocolConvert.ToInt32(fields[0]),
                TypeId = OpenProtocolConvert.ToInt32(fields[1]),
                AutoValue = OpenProtocolConvert.ToBoolean(fields[2]),
                BatchSize = OpenProtocolConvert.ToInt32(fields[3])
            };

            if (revision > 2)
            {
                pset.JobStepName = fields[5];
                pset.JobStepType = OpenProtocolConvert.ToInt32(fields[6]);

                if (revision > 3)
                {
                    pset.IdentifierNumber = OpenProtocolConvert.ToInt32(fields[4]);
                    pset.MaxCoherentNok = OpenProtocolConvert.ToInt32(fields[7]);
                }
                else
                {
                    pset.Socket = OpenProtocolConvert.ToInt32(fields[4]);
                }
            }

            return pset;
        }

        public static IEnumerable<ParameterSet> ParseAll(string section, int revision)
        {
            if (string.IsNullOrWhiteSpace(section))
            {
                yield break;
            }

            var parameterSets = section.Split(';').ToList();
            parameterSets.RemoveAll(string.IsNullOrWhiteSpace); //remove last one which will probably be empty
            foreach (string psetData in parameterSets)
            {
                yield return Parse(psetData, revision);
            }
        }

        public static int Size(int revision)
            => revision switch
            {
                3 => 44,
                4 => 49,
                5 => 51,
                _ => 12,
            };
    }
}
