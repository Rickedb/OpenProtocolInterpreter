using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0124 : MidTester
    {
        [TestMethod]
        public void Mid0124Revision1()
        {
            string package = "00200124   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0124), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0124ByteRevision1()
        {
            string package = "00200124   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0124), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
