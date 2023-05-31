using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0221 : DefaultMidTests<Mid0221>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0221Revision1()
        {
            string package = "00280221            01120021";
            var mid = _midInterpreter.Parse<Mid0221>(package);

            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.IsNotNull(mid.DigitalInputStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0221ByteRevision1()
        {
            string package = "00280221            01120021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0221>(bytes);

            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.IsNotNull(mid.DigitalInputStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
