using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;
using System.Linq;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0035 : MidTester
    {
        [TestMethod]
        public void Mid0035Revision1()
        {
            string package = "00630035001         0101020030040008050003062001-12-01:20:12:45";
            var mid = _midInterpreter.Parse< Mid0035>(package);

            Assert.AreEqual(typeof(Mid0035), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobStatus);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.JobBatchSize);
            Assert.IsNotNull(mid.JobBatchCounter);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0035ByteRevision1()
        {
            string package = "00630035001         0101020030040008050003062001-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0035>(bytes);

            Assert.AreEqual(typeof(Mid0035), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobStatus);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.JobBatchSize);
            Assert.IsNotNull(mid.JobBatchCounter);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0035Revision2()
        {
            string package = "00650035002         010001020030040008050003062001-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0035>(package);

            Assert.AreEqual(typeof(Mid0035), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobStatus);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.JobBatchSize);
            Assert.IsNotNull(mid.JobBatchCounter);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0035ByteRevision2()
        {
            string package = "00650035002         010001020030040008050003062001-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0035>(bytes);

            Assert.AreEqual(typeof(Mid0035), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobStatus);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.JobBatchSize);
            Assert.IsNotNull(mid.JobBatchCounter);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
