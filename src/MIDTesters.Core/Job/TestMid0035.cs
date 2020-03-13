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
        public void Mid0035ByteRevision3()
        {
            string package = "00790035003         010001020030040008050003062001-12-01:20:12:4507120080100912";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0035>(bytes);

            Assert.AreEqual(typeof(Mid0035), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobStatus);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.JobBatchSize);
            Assert.IsNotNull(mid.JobBatchCounter);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsNotNull(mid.JobCurrentStep);
            Assert.IsNotNull(mid.JobTotalNumberOfSteps);
            Assert.IsNotNull(mid.JobStepType);
            Assert.AreEqual(package, mid.Pack());
        }
        
        [TestMethod]
        public void Mid0035ByteRevision4()
        {
            string package = "00830035004         010001020030040008050003062001-12-01:20:12:45071200801009121001";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0035>(bytes);

            Assert.AreEqual(typeof(Mid0035), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobStatus);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.JobBatchSize);
            Assert.IsNotNull(mid.JobBatchCounter);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsNotNull(mid.JobCurrentStep);
            Assert.IsNotNull(mid.JobTotalNumberOfSteps);
            Assert.IsNotNull(mid.JobStepType);
            Assert.IsNotNull(mid.JobTighteningStatus);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
        
        [TestMethod]
        public void Mid0035ByteRevision5()
        {
            string package = "01980035005         010001020030040008050003062001-12-01:20:12:45071200801009121001111234512VINVINN12345678912345678913IdentifierResultPart2xxxx14IdentifierResultPart3xxxx15IdentifierResultPart4xxxx";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0035>(bytes);

            Assert.AreEqual(typeof(Mid0035), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsNotNull(mid.JobStatus);
            Assert.IsNotNull(mid.JobBatchMode);
            Assert.IsNotNull(mid.JobBatchSize);
            Assert.IsNotNull(mid.JobBatchCounter);
            Assert.IsNotNull(mid.TimeStamp);
            Assert.IsNotNull(mid.JobCurrentStep);
            Assert.IsNotNull(mid.JobTotalNumberOfSteps);
            Assert.IsNotNull(mid.JobStepType);
            Assert.IsNotNull(mid.JobTighteningStatus);
            Assert.IsNotNull(mid.JobSequenceNumber);
            Assert.IsNotNull(mid.VinNumber);
            Assert.IsNotNull(mid.IdentifierResultPart2);
            Assert.IsNotNull(mid.IdentifierResultPart3);
            Assert.IsNotNull(mid.IdentifierResultPart4);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
