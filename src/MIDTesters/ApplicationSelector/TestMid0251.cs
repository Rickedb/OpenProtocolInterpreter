using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    public class TestMid0251 : MidTester
    {
        [TestMethod]
        public void Mid0251Revision1()
        {
            string package = "00400251   1        01500210030101101110";
            var mid = _midInterpreter.Parse<Mid0251>(package);

            Assert.AreEqual(typeof(Mid0251), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.NumberOfSockets);
            Assert.IsNotNull(mid.SocketStatus);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0251ByteRevision1()
        {
            string package = "00400251   1        01500210030101101110";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0251>(bytes);

            Assert.AreEqual(typeof(Mid0251), mid.GetType());
            Assert.IsNotNull(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.NumberOfSockets);
            Assert.IsNotNull(mid.SocketStatus);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
