using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.LinkCommunication;

namespace MIDTesters.LinkCommunication
{
    [TestClass]
    public class TestMid9998 : DefaultMidTests<Mid9998>
    {
        [TestMethod]
        public void Mid9998Revision1()
        {
            string package = "00289998            00610003";
            var mid = _midInterpreter.Parse<Mid9998>(package);

            Assert.AreNotEqual(0, mid.MidNumber);
            Assert.IsNotNull(mid.ErrorCode);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid9998ByteRevision1()
        {
            string package = "00289998            00610003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid9998>(bytes);

            Assert.AreNotEqual(0, mid.MidNumber);
            Assert.IsNotNull(mid.ErrorCode);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
