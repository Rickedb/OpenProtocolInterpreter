using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0216 : DefaultMidTests<Mid0216>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0216Revision1()
        {
            string package = "00230216   1        026";
            var mid = _midInterpreter.Parse<Mid0216>(package);

            Assert.IsNotNull(mid.RelayNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0216ByteRevision1()
        {
            string package = "00230216   1        026";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0216>(bytes);

            Assert.IsNotNull(mid.RelayNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
