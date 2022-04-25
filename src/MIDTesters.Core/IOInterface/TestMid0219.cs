using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0219 : DefaultMidTests<Mid0219>
    {
        [TestMethod]
        public void Mid0219Revision1()
        {
            string package = "00230219            102";
            var mid = _midInterpreter.Parse<Mid0219>(package);

            Assert.IsNotNull(mid.RelayNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0219ByteRevision1()
        {
            string package = "00230219            102";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0219>(bytes);

            Assert.IsNotNull(mid.RelayNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
