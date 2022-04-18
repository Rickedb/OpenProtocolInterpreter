using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0261 : MidTester
    {
        [TestMethod]
        public void Mid0261Revision1()
        {
            string package = "00200261   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0261), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0261ByteRevision1()
        {
            string package = "00200261   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0261), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
