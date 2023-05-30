using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid0071 : DefaultMidTests<Mid0071>
    {
        [TestMethod]
        public void Mid0071Revision1()
        {
            string pack = @"00530071001         01E851021031042017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0071>(pack);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        public void Mid0071ByteRevision1()
        {
            string pack = @"00530071001         01E851021031042017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0071>(bytes);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0071Revision2()
        {
            string pack = @"01060071002         01E1021021031042017-12-01:20:12:4505Alarm Text                                        ";
            var mid = _midInterpreter.Parse<Mid0071>(pack);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.AlarmText);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        public void Mid0071ByteRevision2()
        {
            string pack = @"01060071002         01E1021021031042017-12-01:20:12:4505Alarm Text                                        ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0071>(bytes);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsNotNull(mid.ControllerReadyStatus);
            Assert.IsNotNull(mid.ToolReadyStatus);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.AlarmText);
            AssertEqualPackages(bytes, mid);
        }
    }
}
