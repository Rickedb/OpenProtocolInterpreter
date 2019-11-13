using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0031 : MidTester
    {
        [TestMethod]
        public void Mid0031Revision1()
        {
            string package = "00300031001         0401020304";
            var mid = _midInterpreter.Parse<Mid0031>(package);

            Assert.AreEqual(typeof(Mid0031), mid.GetType());
            Assert.IsNotNull(mid.TotalJobs);
            Assert.IsNotNull(mid.JobIds);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0031ByteRevision1()
        {
            string package = "00300031001         0401020304";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0031>(bytes);

            Assert.AreEqual(typeof(Mid0031), mid.GetType());
            Assert.IsNotNull(mid.TotalJobs);
            Assert.IsNotNull(mid.JobIds);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0031Revision2()
        {
            string package = "00640031002         00100001000200030004000500100015001100120019";
            var mid = _midInterpreter.Parse<Mid0031>(package);

            Assert.AreEqual(typeof(Mid0031), mid.GetType());
            Assert.IsNotNull(mid.TotalJobs);
            Assert.IsNotNull(mid.JobIds);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0031ByteRevision2()
        {
            string package = "00640031002         00100001000200030004000500100015001100120019";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0031>(bytes);

            Assert.AreEqual(typeof(Mid0031), mid.GetType());
            Assert.IsNotNull(mid.TotalJobs);
            Assert.IsNotNull(mid.JobIds);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
