using System;
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
            var mid = _midInterpreter.Parse<MID_0251>(package);

            Assert.AreEqual(typeof(MID_0251), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.NumberOfSockets);
            Assert.IsNotNull(mid.SocketStatus);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
