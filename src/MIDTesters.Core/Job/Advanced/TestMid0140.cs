using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Job.Advanced;
using System.Threading;

namespace MIDTesters.Core.Job.Advanced
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
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.JobList);
            Assert.AreNotEqual(0, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreNotEqual(0, mid.MaxTimeForFirstTightening);
            Assert.AreNotEqual(0, mid.MaxTimeToCompleteJob);
            Assert.AreNotEqual(0, mid.DisplayResultAtAutoSelect);
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
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.JobList);
            Assert.AreNotEqual(0, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreNotEqual(0, mid.MaxTimeForFirstTightening);
            Assert.AreNotEqual(0, mid.MaxTimeToCompleteJob);
            Assert.AreNotEqual(0, mid.DisplayResultAtAutoSelect);
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
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.JobList);
            Assert.AreNotEqual(0, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.AreEqual(ToolLoosening.EnableOnlyOnNokTightenings, mid.ToolLoosening);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreEqual(BatchMode.BothOkAndNok, mid.BatchMode);
            Assert.IsTrue(mid.DecrementBatchAtOkLoosening);
            Assert.AreNotEqual(0, mid.MaxTimeForFirstTightening);
            Assert.AreNotEqual(0, mid.MaxTimeToCompleteJob);
            Assert.AreNotEqual(0, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreNotEqual(0, mid.JobSequenceNumber);
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
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0140Revision3()
        {
            string package = "02350140003         01000102Job 1                    03020415:045:10:22:02:10:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:12:12:13:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";
            var mid = _midInterpreter.Parse<Mid0140>(package);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.JobList);
            Assert.AreNotEqual(0, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreNotEqual(0, mid.MaxTimeForFirstTightening);
            Assert.AreNotEqual(0, mid.MaxTimeToCompleteJob);
            Assert.AreNotEqual(0, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreNotEqual(0, mid.JobSequenceNumber);
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
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.JobList);
            Assert.AreNotEqual(0, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreNotEqual(0, mid.MaxTimeForFirstTightening);
            Assert.AreNotEqual(0, mid.MaxTimeToCompleteJob);
            Assert.AreNotEqual(0, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreNotEqual(0, mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 4"), TestCategory("ASCII")]
        public void Mid0140Revision4()
        {
            string package = "02430140004         01000102Job 1                    03020415:045:10:0022:02:0010:0107:Job Action 1             :01:2:1:1:2:2;15:041:10:0016:12:0013:0407:Job Action 2             :02:2:1:1:2:2;05106107108010009009001000901111211311411511605000";
            var mid = _midInterpreter.Parse<Mid0140>(package);

            Assert.AreEqual(typeof(Mid0140), mid.GetType());
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.JobList);
            Assert.AreNotEqual(0, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreNotEqual(0, mid.MaxTimeForFirstTightening);
            Assert.AreNotEqual(0, mid.MaxTimeToCompleteJob);
            Assert.AreNotEqual(0, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreNotEqual(0, mid.JobSequenceNumber);
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
            Assert.AreNotEqual(0, mid.JobId);
            Assert.AreNotEqual(string.Empty, mid.JobName);
            Assert.AreNotEqual(0, mid.NumberOfParameterSets);
            Assert.IsNotNull(mid.JobList);
            Assert.AreNotEqual(0, mid.JobList.Count);
            Assert.AreEqual(ForcedOrder.ForcedOrder, mid.ForcedOrder);
            Assert.IsTrue(mid.LockAtJobDone);
            Assert.IsTrue(mid.RepeatJob);
            Assert.AreNotEqual(0, mid.MaxTimeForFirstTightening);
            Assert.AreNotEqual(0, mid.MaxTimeToCompleteJob);
            Assert.AreNotEqual(0, mid.DisplayResultAtAutoSelect);
            Assert.IsTrue(mid.UsingLineControl);
            Assert.AreEqual(IdentifierPart.Other, mid.IdentifierResultPart);
            Assert.IsTrue(mid.ResultOfNonTightenings);
            Assert.IsTrue(mid.ResetAllIdentifiersAtJobDone);
            Assert.AreEqual(Reserved.G, mid.Reserved);
            Assert.AreNotEqual(0, mid.JobSequenceNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
