using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0220 : DefaultMidTests<Mid0220>
    {
        [TestMethod]
        public void Mid0220Revision1()
        {
            string package = "00230220            120";
            var mid = _midInterpreter.Parse<Mid0220>(package);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0220ByteRevision1()
        {
            string package = "00230220            120";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0220>(bytes);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
