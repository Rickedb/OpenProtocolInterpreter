using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0074 : MidTester
    {
        [TestMethod]
        public void Mid0074Revision1()
        {
            string pack = @"00240074001         E851";
            var mid = _midInterpreter.Parse<Mid0074>(pack);

            Assert.AreEqual(typeof(Mid0074), mid.GetType());
            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(4, mid.ErrorCode.Length);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0074ByteRevision1()
        {
            string pack = @"00240074001         E851";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0074>(bytes);

            Assert.AreEqual(typeof(Mid0074), mid.GetType());
            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(4, mid.ErrorCode.Length);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
        [TestMethod]
        public void Mid0074Revision2()
        {
            string pack = @"00250074002         E8514";
            var mid = _midInterpreter.Parse<Mid0074>(pack);

            Assert.AreEqual(typeof(Mid0074), mid.GetType());
            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(5, mid.ErrorCode.Length);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0074ByteRevision2()
        {
            string pack = @"00250074002         E8514";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0074>(bytes);

            Assert.AreEqual(typeof(Mid0074), mid.GetType());
            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(5, mid.ErrorCode.Length);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
