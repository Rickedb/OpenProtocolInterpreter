using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Job;
using System.Collections.Generic;
using JobParameterSet = OpenProtocolInterpreter.Job.ParameterSet;

namespace MIDTesters.Job
{
    [TestClass]
    [TestCategory("Job")]
    public class TestMid0033 : DefaultMidTests<Mid0033>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0033Revision1()
        {
            string package = "01150033001         010402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0033ByteRevision1()
        {
            string package = "01150033001         010402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0033Revision2()
        {
            string package = "01170033002         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0033ByteRevision2()
        {
            string package = "01170033002         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0033Revision3()
        {
            string package = "01810033003         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:02:Job Step 1 Name          :03;11:015:1:02:01:Job Step 2 Name          :05;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0033ByteRevision3()
        {
            string package = "01810033003         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:02:Job Step 1 Name          :03;11:015:1:02:01:Job Step 2 Name          :05;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0033Revision4()
        {
            string package = "01910033004         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:0002:Job Step 1 Name          :03:05;11:015:1:02:0001:Job Step 2 Name          :05:02;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ByteArray")]
        public void Mid0033ByteRevision4()
        {
            string package = "01910033004         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:0002:Job Step 1 Name          :03:05;11:015:1:02:0001:Job Step 2 Name          :05:02;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ASCII")]
        public void Mid0033Revision5()
        {
            string package = "01950033005         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:0002:0002:Job Step 1 Name          :03:05;11:015:1:0002:0001:Job Step 2 Name          :05:02;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("ByteArray")]
        public void Mid0033ByteRevision5()
        {
            string package = "01950033005         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:0002:0002:Job Step 1 Name          :03:05;11:015:1:0002:0001:Job Step 2 Name          :05:02;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(4, mid.JobId);
            Assert.AreEqual("My Job 4", mid.JobName.TrimEnd());
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.AreEqual(5000, mid.MaxTimeForFirstTightening);
            Assert.AreEqual(70004, mid.MaxTimeToCompleteJob);
            Assert.AreEqual(JobBatchMode.OkAndNokTightenings, mid.JobBatchMode);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.UseLineControl);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreEqual(2, mid.NumberOfParameterSets);
            Assert.AreEqual(2, mid.ParameterSetList.Count);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0033PackRevision1()
        {
            string package = "01150033001         010402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";

            AssertBuildAndParse(package, BuildMid0033(1, new List<JobParameterSet>()
            {
                new JobParameterSet() { ChannelId = 15, TypeId = 11, AutoValue = true, BatchSize = 2 },
                new JobParameterSet() { ChannelId = 11, TypeId = 15, AutoValue = true, BatchSize = 2 }
            }));
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0033PackRevision2()
        {
            string package = "01170033002         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";

            AssertBuildAndParse(package, BuildMid0033(2, new List<JobParameterSet>()
            {
                new JobParameterSet() { ChannelId = 15, TypeId = 11, AutoValue = true, BatchSize = 2 },
                new JobParameterSet() { ChannelId = 11, TypeId = 15, AutoValue = true, BatchSize = 2 }
            }));
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0033PackRevision3()
        {
            string package = "01810033003         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:02:Job Step 1 Name          :03;11:015:1:02:01:Job Step 2 Name          :05;";

#pragma warning disable CS0618 // Socket is the revision 3 layout of the field
            AssertBuildAndParse(package, BuildMid0033(3, new List<JobParameterSet>()
            {
                new JobParameterSet() { ChannelId = 15, TypeId = 11, AutoValue = true, BatchSize = 2, Socket = 2, JobStepName = "Job Step 1 Name", JobStepType = 3 },
                new JobParameterSet() { ChannelId = 11, TypeId = 15, AutoValue = true, BatchSize = 2, Socket = 1, JobStepName = "Job Step 2 Name", JobStepType = 5 }
            }));
#pragma warning restore CS0618
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("Pack")]
        public void Mid0033PackRevision4()
        {
            string package = "01910033004         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:0002:Job Step 1 Name          :03:05;11:015:1:02:0001:Job Step 2 Name          :05:02;";

            AssertBuildAndParse(package, BuildMid0033(4, new List<JobParameterSet>()
            {
                new JobParameterSet() { ChannelId = 15, TypeId = 11, AutoValue = true, BatchSize = 2, IdentifierNumber = 2, JobStepName = "Job Step 1 Name", JobStepType = 3, MaxCoherentNok = 5 },
                new JobParameterSet() { ChannelId = 11, TypeId = 15, AutoValue = true, BatchSize = 2, IdentifierNumber = 1, JobStepName = "Job Step 2 Name", JobStepType = 5, MaxCoherentNok = 2 }
            }));
        }

        [TestMethod]
        [TestCategory("Revision 5"), TestCategory("Pack")]
        public void Mid0033PackRevision5()
        {
            string package = "01950033005         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:0002:0002:Job Step 1 Name          :03:05;11:015:1:0002:0001:Job Step 2 Name          :05:02;";

            AssertBuildAndParse(package, BuildMid0033(5, new List<JobParameterSet>()
            {
                new JobParameterSet() { ChannelId = 15, TypeId = 11, AutoValue = true, BatchSize = 2, IdentifierNumber = 2, JobStepName = "Job Step 1 Name", JobStepType = 3, MaxCoherentNok = 5 },
                new JobParameterSet() { ChannelId = 11, TypeId = 15, AutoValue = true, BatchSize = 2, IdentifierNumber = 1, JobStepName = "Job Step 2 Name", JobStepType = 5, MaxCoherentNok = 2 }
            }));
        }

        private static Mid0033 BuildMid0033(int revision, List<JobParameterSet> parameterSets)
        {
            return new Mid0033(revision)
            {
                JobId = 4,
                JobName = "My Job 4",
                ForcedOrder = ForcedOrder.ForcedOrder,
                MaxTimeForFirstTightening = 5000,
                MaxTimeToCompleteJob = 70004,
                JobBatchMode = JobBatchMode.OkAndNokTightenings,
                LockAtJobDone = true,
                UseLineControl = true,
                RepeatJob = true,
                ToolLoosening = ToolLoosening.EnableOnlyOnNokTightenings,
                Reserved = Reserved.G,
                ParameterSetList = parameterSets
            };
        }
    }
}
