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
            get => GetField(1, (int)DataFields.JOB_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_ID).SetValue(_intConverter.Convert, value);
        }
        public JobStatus JobStatus
        {
            get => (JobStatus)GetField(1, (int)DataFields.JOB_STATUS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)GetField(1, (int)DataFields.JOB_BATCH_MODE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_BATCH_MODE).SetValue(_intConverter.Convert, (int)value);
        }
        public int JobBatchSize
        {
            get => GetField(1, (int)DataFields.JOB_BATCH_SIZE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_BATCH_SIZE).SetValue(_intConverter.Convert, value);
        }
        public int JobBatchCounter
        {
            get => GetField(1, (int)DataFields.JOB_BATCH_COUNTER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_BATCH_COUNTER).SetValue(_intConverter.Convert, value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1, (int)DataFields.TIMESTAMP).GetValue(_datetimeConverter.Convert);
            set => GetField(1, (int)DataFields.TIMESTAMP).SetValue(_datetimeConverter.Convert, value);
        }
        //Rev 3
        public int JobCurrentStep
        {
            get => GetField(3, (int)DataFields.JOB_CURRENT_STEP).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JOB_CURRENT_STEP).SetValue(_intConverter.Convert, value);
        }
        public int JobTotalNumberOfSteps
        {
            get => GetField(3, (int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS).SetValue(_intConverter.Convert, value);
        }
        public int JobStepType
        {
            get => GetField(3, (int)DataFields.JOB_STEP_TYPE).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JOB_STEP_TYPE).SetValue(_intConverter.Convert, value);
        }
        //Rev 4
        public JobTighteningStatus JobTighteningStatus
        {
            get => (JobTighteningStatus)GetField(4, (int)DataFields.JOB_TIGHTENING_STATUS).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.JOB_TIGHTENING_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 5
        public int JobSequenceNumber
        {
            get => GetField(5, (int)DataFields.JOB_SEQUENCE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.JOB_SEQUENCE_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }

        public string VinNumber
        {
            get => GetField(5, (int)DataFields.VIN_NUMBER).Value;
            set => GetField(5, (int)DataFields.VIN_NUMBER).SetValue(value);
        }

        public string IdentifierResultPart2
        {
            get => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART2).Value;
            set => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART2).SetValue(value);
        }

        public string IdentifierResultPart3
        {
            get => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART3).Value;
            set => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART3).SetValue(value);
        }

        public string IdentifierResultPart4
        {
            get => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART4).Value;
            set => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART4).SetValue(value);
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
                                new DataField((int)DataFields.JOB_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_STATUS, 24, 1),
                                new DataField((int)DataFields.JOB_BATCH_MODE, 27, 1),
                                new DataField((int)DataFields.JOB_BATCH_SIZE, 30, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_BATCH_COUNTER, 36, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIMESTAMP, 42, 19)
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_CURRENT_STEP, 65, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS, 70, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_STEP_TYPE, 75, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_TIGHTENING_STATUS, 79, 2, ' ', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    5, new  List<DataField>()
                    {
                        new DataField((int)DataFields.JOB_SEQUENCE_NUMBER, 83, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.VIN_NUMBER, 90 , 25, ' ', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.IDENTIFIER_RESULT_PART2, 117, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.IDENTIFIER_RESULT_PART3, 144, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.IDENTIFIER_RESULT_PART4, 171, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
                    }
                }
            };
        }

        private void HandleRevision()
        {
            var jobIdField = GetField(1, (int)DataFields.JOB_ID);
            if (Header.Revision > 1)
            {
                jobIdField.Size = 4;
            }
            else
            {
                jobIdField.Size = 2;
            }

            int index = jobIdField.Index + jobIdField.Size;
            for (int i = (int)DataFields.JOB_STATUS; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
            }
        }

        protected enum DataFields
        {
            //rev 1 and 2
            JOB_ID,
            JOB_STATUS,
            JOB_BATCH_MODE,
            JOB_BATCH_SIZE,
            JOB_BATCH_COUNTER,
            TIMESTAMP,
            //rev 3
            JOB_CURRENT_STEP,
            JOB_TOTAL_NUMBER_OF_STEPS,
            JOB_STEP_TYPE,
            //rev 4
            JOB_TIGHTENING_STATUS,
            //rev5
            JOB_SEQUENCE_NUMBER,
            VIN_NUMBER,
            IDENTIFIER_RESULT_PART2,
            IDENTIFIER_RESULT_PART3,
            IDENTIFIER_RESULT_PART4
        }
    }

}
