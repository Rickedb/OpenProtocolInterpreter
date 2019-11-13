using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0039 : MidTester
    {
        [TestMethod]
        public void Mid0039Revision1()
        {
            string package = "00220039001         01";
            var mid = _midInterpreter.Parse<Mid0039>(package);

            Assert.AreEqual(typeof(Mid0039), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0039ByteRevision1()
        {
            string package = "00220039001         01";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0039>(bytes);

            Assert.AreEqual(typeof(Mid0039), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0039Revision2()
        {
            string package = "00240039002         0003";
            var mid = _midInterpreter.Parse<Mid0039>(package);

            Assert.AreEqual(typeof(Mid0039), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0039ByteRevision2()
        {
            string package = "00240039002         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0039>(bytes);

            Assert.AreEqual(typeof(Mid0039), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
