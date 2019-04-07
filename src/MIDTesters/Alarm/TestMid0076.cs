using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0076 : MidTester
    {
        [TestMethod]
        public void Mid0076AllRevisions()
        {
            string pack = @"00560076            01102E851031041052017-01-25:10:20:20";
            var mid = _midInterpreter.Parse<Mid0076>(pack);

            Assert.AreEqual(typeof(Mid0076), mid.GetType());
            Assert.IsNotNull(mid.AlarmStatus);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0076ByteAllRevisions()
        {
            string pack = @"00560076            01102E851031041052017-01-25:10:20:20";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0076>(bytes);

            Assert.AreEqual(typeof(Mid0076), mid.GetType());
            Assert.IsNotNull(mid.AlarmStatus);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
