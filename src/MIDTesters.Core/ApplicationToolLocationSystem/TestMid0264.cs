using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0264 : MidTester
    {
        [TestMethod]
        public void Mid0264Revision1()
        {
            string package = "00200264            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0264), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0264ByteRevision1()
        {
            string package = "00200264            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0264), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
