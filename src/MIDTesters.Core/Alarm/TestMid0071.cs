using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;
using System;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid0071 : DefaultMidTests<Mid0071>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0071Revision1()
        {
            string pack = @"00530071001         01E851021031042017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0071>(pack);

            Assert.AreEqual("E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0071ByteRevision1()
        {
            string pack = @"00530071001         01E851021031042017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0071>(bytes);

            Assert.AreEqual("E851", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0071Revision2()
        {
            string pack = @"00540071002         01E1021021031042017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0071>(pack);

            Assert.AreEqual("E1021", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0071ByteRevision2()
        {
            string pack = @"00540071002         01E1021021031042017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0071>(bytes);

            Assert.AreEqual("E1021", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ASCII")]
        public void Mid0071Revision3()
        {
            string pack = @"01090071003         01E1021021031042017-12-01:20:12:4505106Alarm Text                                        ";
            var mid = _midInterpreter.Parse<Mid0071>(pack);

            Assert.AreEqual("E1021", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            Assert.AreEqual("Alarm Text                                        ", mid.AlarmText);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 3"), TestCategory("ByteArray")]
        public void Mid0071ByteRevision3()
        {
            string pack = @"01090071003         01E1021021031042017-12-01:20:12:4505106Alarm Text                                        ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0071>(bytes);

            Assert.AreEqual("E1021", mid.ErrorCode);
            Assert.IsTrue(mid.ControllerReadyStatus);
            Assert.IsTrue(mid.ToolReadyStatus);
            Assert.AreEqual(new DateTime(2017, 12, 1, 20, 12, 45), mid.Time);
            Assert.AreEqual("Alarm Text                                        ", mid.AlarmText);
            AssertEqualPackages(bytes, mid);
        }
    }
}
