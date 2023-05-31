using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    [TestCategory("ApplicationSelector")]
    public class TestMid0251 : DefaultMidTests<Mid0251>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0251Revision1()
        {
            string package = "00400251   1        01500210030101101110";
            var mid = _midInterpreter.Parse<Mid0251>(package);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.NumberOfSockets);
            Assert.IsNotNull(mid.SocketStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0251ByteRevision1()
        {
            string package = "00400251   1        01500210030101101110";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0251>(bytes);

            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.NumberOfSockets);
            Assert.IsNotNull(mid.SocketStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
