using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0225 : DefaultMidTests<Mid0225>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0225Revision1()
        {
            string package = "00230225            055";
            var mid = _midInterpreter.Parse<Mid0225>(package);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0225ByteRevision1()
        {
            string package = "00230225            055";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0225>(bytes);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
