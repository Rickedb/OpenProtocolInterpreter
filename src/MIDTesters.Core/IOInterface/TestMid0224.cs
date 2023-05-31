using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0224 : DefaultMidTests<Mid0224>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0224Revision1()
        {
            string package = "00230224            065";
            var mid = _midInterpreter.Parse<Mid0224>(package);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0224ByteRevision1()
        {
            string package = "00230224            065";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0224>(bytes);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
