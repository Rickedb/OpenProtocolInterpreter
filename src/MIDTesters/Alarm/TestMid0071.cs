using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0071 : MidTester
    {
        [TestMethod]
        public void Mid0071Revision1()
        {
            string pack = @"005300710010        01E851021031042017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<MID_0071>(pack);

            Assert.AreEqual(typeof(MID_0071), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0071Revision2()
        {
            string pack = @"010600710020        01E1021021031042017-12-01:20:12:4505Alarm Text                                        ";
            var mid = _midInterpreter.Parse<MID_0071>(pack);

            Assert.AreEqual(typeof(MID_0071), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.AlarmText);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
