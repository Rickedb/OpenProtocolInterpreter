using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    [TestCategory("ApplicationSelector")]
    public class TestMid0255 : DefaultMidTests<Mid0255>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0255Revision1()
        {
            string package = "00340255            01510221112022";
            var mid = _midInterpreter.Parse<Mid0255>(package);

            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.RedLights);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0255ByteRevision1()
        {
            string package = "00340255            01510221112022";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0255>(bytes);

            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.RedLights);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
