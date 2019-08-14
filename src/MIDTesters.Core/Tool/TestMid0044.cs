using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0044 : MidTester
    {
        [TestMethod]
        public void Mid0044AllRevisions()
        {
            string package = "00200044            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0044), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0044ByteAllRevisions()
        {
            string package = "00200044            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0044), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
