using OpenProtocolInterpreter.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Emulator.Controller.Models
{
    internal class FakeJob
    {
        public int Id { get; set; }
        public ForcedOrder ForcedOrder { get; set; }
        public int MaxTimeForFirstTightening { get; set; }
        public int MaxTimeToCompleteJob { get; set; }
        public JobBatchMode BatchMode { get; set; }
        public bool LockAtJobDone { get; set; }
        public bool UseLineControl { get; set; }
        public bool RepeatJob { get; set; }
        public ToolLoosening ToolLoosening { get; set; }
        public Reserved Reserved { get; set; }
        public List<FakeParameterSet> ParameterSets { get; set; }

        public Mid0033 ToMid0032(int revision = 1)
        {
            return new Mid0033(revision)
            {
                JobId = Id,
                JobName = $"Job {Id}",
                ForcedOrder = ForcedOrder,
                MaxTimeForFirstTightening = MaxTimeForFirstTightening,
                MaxTimeToCompleteJob = MaxTimeToCompleteJob,
                JobBatchMode = BatchMode,
                LockAtJobDone = LockAtJobDone,
                UseLineControl = UseLineControl,
                RepeatJob = RepeatJob,
                ToolLoosening = ToolLoosening,
                Reserved = Reserved,
                ParameterSetList = ParameterSets.Select(x=> x.ToJobParameterSet()).ToList()
            };
        }

        public static FakeJob Random(int id, IEnumerable<FakeParameterSet> availableParameterSets)
        {
            var random = new Random();
            return new FakeJob()
            {
                Id = id,
                ForcedOrder = (ForcedOrder)random.Next(0, 2),
                MaxTimeForFirstTightening = random.Next(0, 9999),
                MaxTimeToCompleteJob = random.Next(0, 99999),
                BatchMode = (JobBatchMode)random.Next(0, 1),
                LockAtJobDone = random.NextBoolean(),
                UseLineControl = random.NextBoolean(),
                RepeatJob = random.NextBoolean(),
                ToolLoosening = (ToolLoosening)random.Next(0, 2),
                Reserved = (Reserved)random.Next(0, 1),
                ParameterSets = availableParameterSets.Take(random.Next(1, availableParameterSets.Count())).ToList()
            };
        }
    }
}
