using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0042 : MidTester
    {
        [TestMethod]
        public void Mid0042AllRevisions()
        {
            string package = "00200042            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0042), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0042ByteAllRevisions()
        {
            string package = "00200042            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0042), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
