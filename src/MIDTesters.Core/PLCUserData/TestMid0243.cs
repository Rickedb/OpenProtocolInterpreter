using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0243 : MidTester
    {
        [TestMethod]
        public void Mid0243Revision1()
        {
            string package = "00200243            ";
            var mid = _midInterpreter.Parse<Mid0243>(package);

            Assert.AreEqual(typeof(Mid0243), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0243ByteRevision1()
        {
            string package = "00200243            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0243), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
