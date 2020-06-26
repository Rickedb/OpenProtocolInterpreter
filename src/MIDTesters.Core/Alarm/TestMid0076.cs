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
        public void Mid0076Revision1()
        {
            string pack = @"00560076001         01102E851031041052017-01-25:10:20:20";
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
        public void Mid0076ByteRevision1()
        {
            string pack = @"00560076001         01102E851031041052017-01-25:10:20:20";
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

        [TestMethod]
        public void Mid0076Revision2()
        {
            string pack = @"00570076002         01102 E851031041052017-01-25:10:20:20";
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
        public void Mid0076ByteRevision2()
        {
            string pack = @"00570076002         01102 E851031041052017-01-25:10:20:20";
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

        [TestMethod]
        public void Mid0076Revision3()
        {
            string pack = @"00600076003         01102 E851031041052017-01-25:10:20:20061";
            var mid = _midInterpreter.Parse<Mid0076>(pack);

            Assert.AreEqual(typeof(Mid0076), mid.GetType());
            Assert.IsNotNull(mid.AlarmStatus);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.ToolHealth);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0076ByteRevision3()
        {
            string pack = @"00600076003         01102 E851031041052017-01-25:10:20:20061";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0076>(bytes);

            Assert.AreEqual(typeof(Mid0076), mid.GetType());
            Assert.IsNotNull(mid.AlarmStatus);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.ToolHealth);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
