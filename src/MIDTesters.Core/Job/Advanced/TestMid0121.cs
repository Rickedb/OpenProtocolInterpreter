using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0121 : MidTester
    {
        [TestMethod]
        public void Mid0121Revision1()
        {
            string package = "00200121   0        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0121), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0121ByteRevision1()
        {
            string package = "00200121   0        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0121), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
