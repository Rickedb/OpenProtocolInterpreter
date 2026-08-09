using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Alarm;
using System;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid0076 : DefaultMidTests<Mid0076>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0076Revision1()
        {
            string pack = @"00560076001         01102E851031041052017-01-25:10:20:20";
            var mid = _midInterpreter.Parse<Mid0076>(pack);

            Assert.IsTrue(mid.AlarmStatus);
            Assert.AreEqual("E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0076ByteRevision1()
        {
            string pack = @"00560076001         01102E851031041052017-01-25:10:20:20";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0076>(bytes);

            Assert.IsTrue(mid.AlarmStatus);
            Assert.AreEqual("E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0076Revision2()
        {
            string pack = @"00570076002         01102 E851031041052017-01-25:10:20:20";
            var mid = _midInterpreter.Parse<Mid0076>(pack);

            Assert.IsTrue(mid.AlarmStatus);
            Assert.AreEqual(" E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0076ByteRevision2()
        {
            string pack = @"00570076002         01102 E851031041052017-01-25:10:20:20";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0076>(bytes);

            Assert.IsTrue(mid.AlarmStatus);
            Assert.AreEqual(" E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0076Revision3()
        {
            string pack = @"00600076003         01102 E851031041052017-01-25:10:20:20061";
            var mid = _midInterpreter.Parse<Mid0076>(pack);

            Assert.IsTrue(mid.AlarmStatus);
            Assert.AreEqual(" E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            Assert.AreEqual(ToolHealth.Ok, mid.ToolHealth);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0076ByteRevision3()
        {
            string pack = @"00600076003         01102 E851031041052017-01-25:10:20:20061";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0076>(bytes);

            Assert.IsTrue(mid.AlarmStatus);
            Assert.AreEqual(" E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            Assert.AreEqual(ToolHealth.Ok, mid.ToolHealth);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0076PackRevision1()
        {
            string pack = @"00560076001         01102E851031041052017-01-25:10:20:20";

            AssertBuildAndParse(pack, new Mid0076(1)
            {
                AlarmStatus = true,
                ErrorCode = "E851",
                ControllerReadyStatus = true,
                ToolReadyStatus = true,
                Time = new DateTime(2017, 1, 25, 10, 20, 20)
            });
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0076PackRevision2()
        {
            string pack = @"00570076002         01102 E851031041052017-01-25:10:20:20";

            AssertBuildAndParse(pack, new Mid0076(2)
            {
                AlarmStatus = true,
                ErrorCode = " E851",
                ControllerReadyStatus = true,
                ToolReadyStatus = true,
                Time = new DateTime(2017, 1, 25, 10, 20, 20)
            });
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("Pack")]
        public void Mid0076PackRevision3()
        {
            string pack = @"00600076003         01102 E851031041052017-01-25:10:20:20061";

            AssertBuildAndParse(pack, new Mid0076(3)
            {
                AlarmStatus = true,
                ErrorCode = " E851",
                ControllerReadyStatus = true,
                ToolReadyStatus = true,
                Time = new DateTime(2017, 1, 25, 10, 20, 20),
                ToolHealth = ToolHealth.Ok
            });
        }
    }
}
