using OpenProtocolInterpreter.Job;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Converters
{
    internal class JobConverter : IValueConverter<IEnumerable<MID_0033.Job>>
    {
        private readonly int _revision;

        public JobConverter(IValueConverter<int> intConverter, int revision)
        {
            _revision = revision;
        }

        public IEnumerable<MID_0033.Job> Convert(string value)
        {
            string[] jobDatas = value.Substring(2, value.Length - 1).Split(';');
            foreach (string jobData in jobDatas)
            {
                string[] fields = jobData.Split(':');
                if (_revision < 3)
                    yield return GetRevision1or2(fields);
                else
                    yield return GetRevision3(fields);
            }
        }

        public string Convert(IEnumerable<MID_0033.Job> value)
        {
            List<string> packages = new List<string>();
            if (_revision < 3)
            {
                foreach (var job in value)
                    packages.Add(GetRevision1or2(job));
            }
            else
            {
                foreach (var job in value)
                    packages.Add(GetRevision3(job));
            }
            return string.Join(";", packages) + ";";
        }

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<MID_0033.Job> value)
        {
            return Convert(value);
        }

        private MID_0033.Job GetRevision1or2(string[] fields)
        {
            var job = new MID_0033.Job();
            GetFields(job.RevisionsByFields[1], fields);
            return job;
        }

        private string GetRevision1or2(MID_0033.Job job) => string.Join(":", GetFields(job.RevisionsByFields[1]));

        private MID_0033.Job GetRevision3(string[] fields)
        {
            var job = GetRevision1or2(fields);
            GetFields(job.RevisionsByFields[3], fields);
            return job;
        }

        private string GetRevision3(MID_0033.Job job)
        {
            List<string> fields = new List<string>(GetFields(job.RevisionsByFields[1]));
            fields.AddRange(GetFields(job.RevisionsByFields[3]));
            return string.Join(":", fields);
        }

        private IEnumerable<string> GetFields(List<DataField> fields)
        {
            foreach (var field in fields)
                yield return field.Value;
        }

        private IEnumerable<DataField> GetFields(List<DataField> revisionFields, string[] fields)
        {
            foreach (var field in revisionFields)
                field.Value = fields[field.Index];

            return revisionFields;
        }
    }
}
