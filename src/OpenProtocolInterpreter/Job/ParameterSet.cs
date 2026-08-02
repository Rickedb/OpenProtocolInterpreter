using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            => Parse(section.AsSpan(), revision);

        public static ParameterSet Parse(ReadOnlySpan<char> section, int revision)
        {
            var remaining = section;
            var pset = new ParameterSet()
            {
                ChannelId = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':')),
                TypeId = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':')),
                AutoValue = OpenProtocolConvert.ToBoolean(NextField(ref remaining, ':')),
                BatchSize = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'))
            };

            if (revision > 2)
            {
                var socketOrIdentifierNumber = NextField(ref remaining, ':');
                pset.JobStepName = NextField(ref remaining, ':').ToString();
                pset.JobStepType = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));

                if (revision > 3)
                {
                    pset.IdentifierNumber = OpenProtocolConvert.ToInt32(socketOrIdentifierNumber);
                    pset.MaxCoherentNok = OpenProtocolConvert.ToInt32(NextField(ref remaining, ':'));
                }
                else
                {
                    pset.Socket = OpenProtocolConvert.ToInt32(socketOrIdentifierNumber);
                }
            }

            return pset;
        }

        public static IEnumerable<ParameterSet> ParseAll(string section, int revision)
            => ParseAll(section.AsSpan(), revision);

        public static IEnumerable<ParameterSet> ParseAll(ReadOnlySpan<char> section, int revision)
        {
            if (section.IsWhiteSpace() || section.IsEmpty)
                return Array.Empty<ParameterSet>();

            var result = new List<ParameterSet>();
            var remaining = section;
            while (!remaining.IsEmpty)
            {
                var psetData = NextField(ref remaining, ';');
                if (!psetData.IsWhiteSpace())
                    result.Add(Parse(psetData, revision));
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

        public static int Size(int revision)
            => revision switch
            {
                1 => 12,
                2 => 12,
                3 => 44,
                4 => 49,
                5 => 51,
                _ => 51, //Default will always be the last
            };
    }

    public class ParameterSetCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public ParameterSetCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public ParameterSetCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<ParameterSet>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackParameterSets,
                DefaultParser = ParseParameterSets
            }.Bind(mid, propertyInfo);
        }

        private string PackParameterSets(char paddingChar, int size, PaddingOrientation orientation, List<ParameterSet> parameterSets)
        {
            var list = new List<string>();
            foreach (var parameterSet in parameterSets)
                list.Add(parameterSet.Pack(Revision));

            return string.Concat(string.Join(";", list), ";");
        }

        private List<ParameterSet> ParseParameterSets(string value)
            => ParameterSet.ParseAll(value, Revision).ToList();
    }
}
