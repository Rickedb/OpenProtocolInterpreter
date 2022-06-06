using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0217 : DefaultMidTests<Mid0217>
    {
        [TestMethod]
        public void Mid0217Revision1()
        {
            string package = "00280217   1        01026021";
            var mid = _midInterpreter.Parse<Mid0217>(package);

            Assert.IsNotNull(mid.RelayNumber);
            Assert.IsNotNull(mid.RelayStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
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
