using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0217 : DefaultMidTests<Mid0217>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0217Revision1()
        {
            string package = "00280217   1        01026021";
            var mid = _midInterpreter.Parse<Mid0217>(package);

            Assert.IsNotNull(mid.RelayNumber);
            Assert.IsNotNull(mid.RelayStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0217ByteRevision1()
        {
            string package = "00280217   1        01026021";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0217>(bytes);

            Assert.IsNotNull(mid.RelayNumber);
            Assert.IsNotNull(mid.RelayStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
