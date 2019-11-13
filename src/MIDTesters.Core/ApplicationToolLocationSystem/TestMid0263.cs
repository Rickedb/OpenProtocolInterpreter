using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0263 : MidTester
    {
        [TestMethod]
        public void Mid0263Revision1()
        {
            string package = "00200263            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0263), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0263ByteRevision1()
        {
            string package = "00200263            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0263), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
