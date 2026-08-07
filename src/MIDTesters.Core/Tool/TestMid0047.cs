using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
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

            Assert.AreEqual(PairingHandlingType.FetchLatestPairingStatus, mid.PairingHandlingType);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0047ByteRevision1()
        {
            string package = "00240047001         0103";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0047>(bytes);

            Assert.AreEqual(PairingHandlingType.FetchLatestPairingStatus, mid.PairingHandlingType);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0047PackRevision1()
        {
            string package = "00240047001         0103";

            AssertBuildAndParse(package, new Mid0047()
            {
                PairingHandlingType = PairingHandlingType.FetchLatestPairingStatus
            });
        }
    }
}
