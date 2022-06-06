using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    public class TestMid0254 : DefaultMidTests<Mid0254>
    {
        [TestMethod]
        public void Mid0254Revision1()
        {
            string package = "00340254            01110201221022";
            var mid = _midInterpreter.Parse<Mid0254>(package);

            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.GreenLights);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0254ByteRevision1()
        {
            string package = "00340254            01110201221022";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0254>(bytes);

            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.GreenLights);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
