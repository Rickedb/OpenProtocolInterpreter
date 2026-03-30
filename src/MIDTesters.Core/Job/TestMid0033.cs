using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Job;

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
    }
}
