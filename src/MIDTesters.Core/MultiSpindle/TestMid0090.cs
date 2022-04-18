using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0090 : MidTester
    {
        [TestMethod]
        public void Mid0090AllRevisions()
        {
            string pack = @"00200090   1        ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0090), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0090ByteRevision1()
        {
            string package = @"00200090   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0090), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
