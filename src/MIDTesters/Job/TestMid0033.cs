using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0033 : MidTester
    {
        [TestMethod]
        public void Mid0033Revision1()
        {
            string package = "01150033001         010402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0033ByteRevision1()
        {
            string package = "01150033001         010402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0033Revision2()
        {
            string package = "01170033002         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0033ByteRevision2()
        {
            string package = "01170033002         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02;11:015:1:02;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0033Revision3()
        {
            string package = "01810033003         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:02:Job Step 1 Name          :03;11:015:1:02:01:Job Step 2 Name          :05;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0033ByteRevision3()
        {
            string package = "01810033003         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:02:Job Step 1 Name          :03;11:015:1:02:01:Job Step 2 Name          :05;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0033Revision4()
        {
            string package = "01910033004         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:0002:Job Step 1 Name          :03:05;11:015:1:02:0001:Job Step 2 Name          :05:02;";
            var mid = _midInterpreter.Parse<Mid0033>(package);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0033ByteRevision4()
        {
            string package = "01910033004         01000402My Job 4                 031045000057000406107108109110211112021315:011:1:02:0002:Job Step 1 Name          :03:05;11:015:1:02:0001:Job Step 2 Name          :05:02;";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0033>(bytes);

            Assert.AreEqual(typeof(Mid0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobName);
            Assert.IsNotNull(mid.ForcedOrder);
            Assert.IsNotNull(mid.MaxTimeForFirstTightening);
            Assert.IsNotNull(mid.MaxTimeToCompleteJob);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.LockAtJobDone);
            Assert.IsNotNull(mid.UseLineControl);
            Assert.IsNotNull(mid.RepeatJob);
            Assert.IsNotNull(mid.ToolLoosening);
            Assert.IsNotNull(mid.Reserved);
            Assert.IsNotNull(mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.ParameterSetList);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
