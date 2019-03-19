using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0213 : MidTester
    {
        [TestMethod]
        public void Mid0213Revision1()
        {
            string package = "00200213            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0213), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0213ByteRevision1()
        {
            string package = "00200213            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0213), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
