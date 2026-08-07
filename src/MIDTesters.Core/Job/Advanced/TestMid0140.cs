using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Job.Advanced;
using System.Threading;

using System.Collections.Generic;
namespace MIDTesters.Job.Advanced
{
    [TestClass]
    [TestCategory("Job"), TestCategory("Advanced Job")]
    public class TestMid0140 : DefaultMidTests<Mid0140>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0140Revision1()
        {
            string package = "01440140            01000102Job 1                    03020414:045:0:22:02;01:013:1:10:01;0510610720810911011111201001310000140090151161171181191";
            var mid = _midInterpreter.Parse<Mid0140>(package);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(10000, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0140ByteRevision1()
        {
            string package = "01440140            01000102Job 1                    03020414:045:0:22:02;01:013:1:10:01;0510610720810911011111201001310000140090151161171181191";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0140>(bytes);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(10000, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0140Revision2()
        {
            string package = "02250140002         01000102Job 1                    03020415:045:0:22:02:10:0107:Job Action 1             :01;15:045:0:12:12:13:0407:Job Action 2             :02;05106107208109110111112010013100001400901511611711811912000120";
            var mid = _midInterpreter.Parse<Mid0140>(package);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(10000, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(120, mid.JobSequenceNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0140ByteRevision2()
        {
            string package = "02250140002         01000102Job 1                    03020415:045:0:22:02:10:0107:Job Action 1             :01;15:045:0:12:12:13:0407:Job Action 2             :02;05106107208109110111112010013100001400901511611711811912000120";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0140>(bytes);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0140Revision3()
        {
            string package = "02350140003         01000102Job 1                    03020415:045:10:22:02:10:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:12:12:13:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";
            var mid = _midInterpreter.Parse<Mid0140>(package);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(900, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(5000, mid.JobSequenceNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0140ByteRevision3()
        {
            string package = "02350140003         01000102Job 1                    03020415:045:10:22:02:10:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:12:12:13:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0140>(bytes);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(900, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(5000, mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0140Revision4()
        {
            string package = "02430140004         01000102Job 1                    03020415:045:10:0022:02:0010:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:0016:12:0013:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";
            var mid = _midInterpreter.Parse<Mid0140>(package);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(900, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(5000, mid.JobSequenceNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0140ByteRevision4()
        {
            string package = "02350140003         01000102Job 1                    03020415:045:10:22:02:10:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:12:12:13:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0140>(bytes);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(900, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(5000, mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 999"), TestCategory("ASCII")]
        public void Mid0140Revision999()
        {
            string package = "01500140999         01000102Job 1                    03020414:045:0:22:02:10;01:013:1:10:01:05;0510610720810911011111201001310000140090151161171181191";
            var mid = _midInterpreter.Parse<Mid0140>(package);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(10000, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 999"), TestCategory("ByteArray")]
        public void Mid0140ByteRevision999()
        {
            string package = "01500140999         01000102Job 1                    03020414:045:0:22:02:10;01:013:1:10:01:05;0510610720810911011111201001310000140090151161171181191";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0140>(bytes);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreEqual(1, mid.JobId);
            Assert.AreEqual("Job 1", mid.JobName.TrimEnd());
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreEqual(100, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(10000, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(90, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0140PackRevision1()
        {
            string package = "01440140            01000102Job 1                    03020414:045:0:22:02;01:013:1:10:01;0510610720810911011111201001310000140090151161171181191";

            AssertBuildAndParse(package, BuildMid0140(1, new List<AdvancedJob>()
            {
                new AdvancedJob() { ChannelId = 14, ProgramId = 45, AutoSelect = AutoSelect.None, BatchSize = 22, MaxCoherentNok = 2 },
                new AdvancedJob() { ChannelId = 1, ProgramId = 13, AutoSelect = AutoSelect.AutoNextChange, BatchSize = 10, MaxCoherentNok = 1 }
            }), true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0140PackRevision2()
        {
            string package = "02250140002         01000102Job 1                    03020415:045:0:22:02:10:0107:Job Action 1             :01;15:045:0:12:12:13:0407:Job Action 2             :02;05106107208109110111112010013100001400901511611711811912000120";

            var mid = BuildMid0140(2, new List<AdvancedJob>()
            {
                new AdvancedJob() { ChannelId = 15, ProgramId = 45, AutoSelect = AutoSelect.None, BatchSize = 22, MaxCoherentNok = 2, BatchCounter = 10, IdentifierNumber = 107, JobStepName = "Job Action 1", JobStepType = 1 },
                new AdvancedJob() { ChannelId = 15, ProgramId = 45, AutoSelect = AutoSelect.None, BatchSize = 12, MaxCoherentNok = 12, BatchCounter = 13, IdentifierNumber = 407, JobStepName = "Job Action 2", JobStepType = 2 }
            });
            mid.JobSequenceNumber = 120;

            AssertBuildAndParse(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0140PackRevision3()
        {
            string package = "02350140003         01000102Job 1                    03020415:045:10:22:02:10:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:12:12:13:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";

            AssertBuildAndParse(package, BuildMid0140Revision3Onwards(3, new List<AdvancedJob>()
            {
                BuildAdvancedJobRevision3(programId: 45, batchSize: 22, maxCoherentNok: 2, batchCounter: 10, identifierNumber: 107, jobStepName: "Job Action 1", jobStepType: 1),
                BuildAdvancedJobRevision3(programId: 41, batchSize: 12, maxCoherentNok: 12, batchCounter: 13, identifierNumber: 407, jobStepName: "Job Action 2", jobStepType: 2)
            }));
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("Pack")]
        public void Mid0140PackRevision4()
        {
            string package = "02430140004         01000102Job 1                    03020415:045:10:0022:02:0010:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:0016:12:0013:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";

            AssertBuildAndParse(package, BuildMid0140Revision3Onwards(4, new List<AdvancedJob>()
            {
                BuildAdvancedJobRevision3(programId: 45, batchSize: 22, maxCoherentNok: 2, batchCounter: 10, identifierNumber: 107, jobStepName: "Job Action 1", jobStepType: 1),
                BuildAdvancedJobRevision3(programId: 41, batchSize: 16, maxCoherentNok: 12, batchCounter: 13, identifierNumber: 407, jobStepName: "Job Action 2", jobStepType: 2)
            }));
        }

        [TestMethod]
        [TestCategory("Revision 999"), TestCategory("Pack")]
        public void Mid0140PackRevision999()
        {
            string package = "01500140999         01000102Job 1                    03020414:045:0:22:02:10;01:013:1:10:01:05;0510610720810911011111201001310000140090151161171181191";

            AssertBuildAndParse(package, BuildMid0140(999, new List<AdvancedJob>()
            {
                new AdvancedJob() { ChannelId = 14, ProgramId = 45, AutoSelect = AutoSelect.None, BatchSize = 22, MaxCoherentNok = 2, BatchCounter = 10 },
                new AdvancedJob() { ChannelId = 1, ProgramId = 13, AutoSelect = AutoSelect.AutoNextChange, BatchSize = 10, MaxCoherentNok = 1, BatchCounter = 5 }
            }));
        }

        private static Mid0140 BuildMid0140(int revision, List<AdvancedJob> jobList)
        {
            return new Mid0140(revision)
            {
                JobId = 1,
                JobName = "Job 1",
                NumberOfParameterSets = 2,
                JobList = jobList,
                ForcedOrder = ForcedOrder.ForcedOrder,
                LockAtJobDone = true,
                ToolLoosening = ToolLoosening.EnableOnlyOnNokTightenings,
                RepeatJob = true,
                BatchMode = BatchMode.BothOkAndNok,
                BatchStatusAtIncrement = true,
                DecrementBatchAtOkLoosening = true,
                MaxTimeForFirstTightening = 100,
                MaxTimeToCompleteJob = 10000,
                DisplayResultAtAutoSelect = 90,
                UsingLineControl = true,
                IdentifierResultPart = IdentifierPart.Other,
                ResultOfNonTightenings = true,
                ResetAllIdentifiersAtJobDone = true,
                Reserved = Reserved.G
            };
        }

        private static Mid0140 BuildMid0140Revision3Onwards(int revision, List<AdvancedJob> jobList)
        {
            return new Mid0140(revision)
            {
                JobId = 1,
                JobName = "Job 1",
                NumberOfParameterSets = 2,
                JobList = jobList,
                ForcedOrder = ForcedOrder.ForcedOrder,
                LockAtJobDone = true,
                RepeatJob = true,
                MaxTimeForFirstTightening = 100,
                MaxTimeToCompleteJob = 900,
                DisplayResultAtAutoSelect = 90,
                UsingLineControl = true,
                IdentifierResultPart = IdentifierPart.Other,
                ResultOfNonTightenings = true,
                ResetAllIdentifiersAtJobDone = true,
                Reserved = Reserved.G,
                JobSequenceNumber = 5000
            };
        }

        private static AdvancedJob BuildAdvancedJobRevision3(int programId, int batchSize, int maxCoherentNok, int batchCounter, int identifierNumber, string jobStepName, int jobStepType)
        {
            return new AdvancedJob()
            {
                ChannelId = 15,
                ProgramId = programId,
                AutoSelect = AutoSelect.ToolDisplay,
                BatchSize = batchSize,
                MaxCoherentNok = maxCoherentNok,
                BatchCounter = batchCounter,
                IdentifierNumber = identifierNumber,
                JobStepName = jobStepName,
                JobStepType = jobStepType,
                ToolLoosening = ToolLoosening.EnableOnlyOnNokTightenings,
                JobBatchMode = BatchMode.BothOkAndNok,
                BatchStatusAtIncrement = BatchStatusAtIncrement.Nok,
                DecrementBatchAfterLoosening = DecrementBatchAfterLoosening.AfterOk,
                CurrentBatchStatus = CurrentBatchStatus.Nok
            };
        }
    }
}
