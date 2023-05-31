using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0047 : DefaultMidTests<Mid0047>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0047Revision1()
        {
            string package = "00240047001         0103";
            var mid = _midInterpreter.Parse<Mid0047>(package);

            Assert.IsNotNull(mid.PairingHandlingType);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
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
