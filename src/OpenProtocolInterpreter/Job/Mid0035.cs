using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// <para>Job info</para>
    ///     <para>The Job info subscriber will receive a Job info message after a Job has been selected and after each
    ///     tightening performed in the Job.The Job info consists of the ID of the currently running Job, the Job
    ///     status, the Job batch mode, the Job batch size and the Job batch counter.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0036"/></para>
    /// </summary>
    public class Mid0035 : Mid, IJob, IController, IAcknowledgeable<Mid0036>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _datetimeConverter;
        public const int MID = 35;

        public int JobId
        {
            get => GetField(1, (int)DataFields.JobId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobId).SetValue(_intConverter.Convert, value);
        }
        public JobStatus JobStatus
        {
            get => (JobStatus)GetField(1, (int)DataFields.JobStatus).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)GetField(1, (int)DataFields.JobBatchMode).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobBatchMode).SetValue(_intConverter.Convert, (int)value);
        }
        public int JobBatchSize
        {
            get => GetField(1, (int)DataFields.JobBatchSize).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobBatchSize).SetValue(_intConverter.Convert, value);
        }
        public int JobBatchCounter
        {
            get => GetField(1, (int)DataFields.JobBatchCounter).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobBatchCounter).SetValue(_intConverter.Convert, value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1, (int)DataFields.Timestamp).GetValue(_datetimeConverter.Convert);
            set => GetField(1, (int)DataFields.Timestamp).SetValue(_datetimeConverter.Convert, value);
        }
        //Rev 3
        public int JobCurrentStep
        {
            get => GetField(3, (int)DataFields.JobCurrentStep).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JobCurrentStep).SetValue(_intConverter.Convert, value);
        }
        public int JobTotalNumberOfSteps
        {
            get => GetField(3, (int)DataFields.JobTotalNumberOfSteps).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JobTotalNumberOfSteps).SetValue(_intConverter.Convert, value);
        }
        public int JobStepType
        {
            get => GetField(3, (int)DataFields.JobStepType).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JobStepType).SetValue(_intConverter.Convert, value);
        }
        //Rev 4
        public JobTighteningStatus JobTighteningStatus
        {
            get => (JobTighteningStatus)GetField(4, (int)DataFields.JobTighteningStatus).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.JobTighteningStatus).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 5
        public int JobSequenceNumber
        {
            get => GetField(5, (int)DataFields.JobSequenceNumber).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.JobSequenceNumber).SetValue(_intConverter.Convert, (int)value);
        }

        public string VinNumber
        {
            get => GetField(5, (int)DataFields.VinNumber).Value;
            set => GetField(5, (int)DataFields.VinNumber).SetValue(value);
        }

        public string IdentifierResultPart2
        {
            get => GetField(5, (int)DataFields.IdentifierResultPart2).Value;
            set => GetField(5, (int)DataFields.IdentifierResultPart2).SetValue(value);
        }

        public string IdentifierResultPart3
        {
            get => GetField(5, (int)DataFields.IdentifierResultPart3).Value;
            set => GetField(5, (int)DataFields.IdentifierResultPart3).SetValue(value);
        }

        public string IdentifierResultPart4
        {
            get => GetField(5, (int)DataFields.IdentifierResultPart4).Value;
            set => GetField(5, (int)DataFields.IdentifierResultPart4).SetValue(value);
        }

        public Mid0035() : this(DEFAULT_REVISION)
        {

        }

        public Mid0035(Header header) : base(header)
        {
        }

        public Mid0035(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
            _intConverter = new Int32Converter();
            _datetimeConverter = new DateConverter();
            HandleRevision();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevision();
            ProcessDataFields(package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.JobId, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.JobStatus, 24, 1),
                                new DataField((int)DataFields.JobBatchMode, 27, 1),
                                new DataField((int)DataFields.JobBatchSize, 30, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.JobBatchCounter, 36, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Timestamp, 42, 19)
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.JobCurrentStep, 65, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.JobTotalNumberOfSteps, 70, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.JobStepType, 75, 2, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.JobTighteningStatus, 79, 2, ' ', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    5, new  List<DataField>()
                    {
                        new DataField((int)DataFields.JobSequenceNumber, 83, 5, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.VinNumber, 90 , 25, ' ', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.IdentifierResultPart2, 117, 25, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.IdentifierResultPart3, 144, 25, '0', DataField.PaddingOrientations.LeftPadded),
                        new DataField((int)DataFields.IdentifierResultPart4, 171, 25, '0', DataField.PaddingOrientations.LeftPadded),
                    }
                }
            };
        }

        private void HandleRevision()
        {
            var jobIdField = GetField(1, (int)DataFields.JobId);
            if (Header.Revision > 1)
            {
                jobIdField.Size = 4;
            }
            else
            {
                jobIdField.Size = 2;
            }

            int index = jobIdField.Index + jobIdField.Size;
            for (int i = (int)DataFields.JobStatus; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
            }
        }

        protected enum DataFields
        {
            //rev 1 and 2
            JobId,
            JobStatus,
            JobBatchMode,
            JobBatchSize,
            JobBatchCounter,
            Timestamp,
            //rev 3
            JobCurrentStep,
            JobTotalNumberOfSteps,
            JobStepType,
            //rev 4
            JobTighteningStatus,
            //rev5
            JobSequenceNumber,
            VinNumber,
            IdentifierResultPart2,
            IdentifierResultPart3,
            IdentifierResultPart4
        }
    }

}
