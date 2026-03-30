using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.LinkCommunication;

namespace MIDTesters.LinkCommunication
{
    [TestClass]
    [TestCategory("LinkCommunication")]
    public class TestMid9998 : DefaultMidTests<Mid9998>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid9998Revision1()
        {
            string package = "00289998            00610003";
            var mid = _midInterpreter.Parse<Mid9998>(package);

            Assert.AreEqual(61, mid.MidNumber);
            Assert.AreEqual(LinkCommunicationError.InvalidSequenceNumber, mid.ErrorCode);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid9998ByteRevision1()
        {
            string package = "00289998            00610003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid9998>(bytes);

            Assert.AreEqual(61, mid.MidNumber);
            Assert.AreEqual(LinkCommunicationError.InvalidSequenceNumber, mid.ErrorCode);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
