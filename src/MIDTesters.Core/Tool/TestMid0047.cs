using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0047 : DefaultMidTests<Mid0047>
    {
        [TestMethod]
        public void Mid0047Revision1()
        {
            string package = "00240047001         0103";
            var mid = _midInterpreter.Parse<Mid0047>(package);

            Assert.IsNotNull(mid.PairingHandlingType);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0047ByteRevision1()
        {
            string package = "00240047001         0103";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0047>(bytes);

            Assert.IsNotNull(mid.PairingHandlingType);
            AssertEqualPackages(bytes, mid);
        }
    }
}
