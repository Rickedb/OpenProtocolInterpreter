using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0225 : DefaultMidTests<Mid0225>
    {
        [TestMethod]
        public void Mid0225Revision1()
        {
            string package = "00230225            055";
            var mid = _midInterpreter.Parse<Mid0225>(package);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
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
