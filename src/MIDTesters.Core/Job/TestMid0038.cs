using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;
using System.Linq;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0038 : MidTester
    {
        [TestMethod]
        public void Mid0038Revision1()
        {
            string package = "00220038001         01";
            var mid = _midInterpreter.Parse<Mid0038>(package);

            Assert.AreEqual(typeof(Mid0038), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0038ByteRevision1()
        {
            string package = "00220038001         01";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0038>(bytes);

            Assert.AreEqual(typeof(Mid0038), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0038Revision2()
        {
            string package = "00240038002         0001";
            var mid = _midInterpreter.Parse<Mid0038>(package);

            Assert.AreEqual(typeof(Mid0038), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0038ByteRevision2()
        {
            string package = "00240038002         0001";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0038>(bytes);

            Assert.AreEqual(typeof(Mid0038), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
