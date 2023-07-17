using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0045 : DefaultMidTests<Mid0045>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0045Revision1()
        {
            string package = "00310045            01402003000";
            var mid = _midInterpreter.Parse<Mid0045>(package);

            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0045ByteRevision1()
        {
            string package = "00310045            01402003000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0045>(bytes);

            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0045Revision2()
        {
            string package = "00350045002         014020030000301";
            var mid = _midInterpreter.Parse<Mid0045>(package);

            Assert.AreEqual(typeof(Mid0045), mid.GetType());
            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.ChannelNumber);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0045ByteRevision2()
        {
            string package = "00350045002         014020030000302";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0045>(bytes);

            Assert.AreEqual(typeof(Mid0045), mid.GetType());
            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.ChannelNumber);
            AssertEqualPackages(bytes, mid);
        }
    }
}
