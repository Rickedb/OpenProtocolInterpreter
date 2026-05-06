using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.SocketTray;

namespace MIDTesters.SocketTray
{
    [TestClass]
    [TestCategory("SocketTray")]
    public class TestMid0524 : DefaultMidTests<Mid0524>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0524Revision1()
        {
            string package = "00440524            011022033044055066077081";
            var mid = _midInterpreter.Parse<Mid0524>(package);

            Assert.AreEqual(1, mid.Socket1);
            Assert.AreEqual(2, mid.Socket2);
            Assert.AreEqual(3, mid.Socket3);
            Assert.AreEqual(4, mid.Socket4);
            Assert.AreEqual(5, mid.Socket5);
            Assert.AreEqual(6, mid.Socket6);
            Assert.AreEqual(7, mid.Socket7);
            Assert.AreEqual(1, mid.Socket8);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0524ByteRevision1()
        {
            string package = "00440524            011022033044055066077081";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0524>(bytes);

            Assert.AreEqual(1, mid.Socket1);
            Assert.AreEqual(2, mid.Socket2);
            Assert.AreEqual(3, mid.Socket3);
            Assert.AreEqual(4, mid.Socket4);
            Assert.AreEqual(5, mid.Socket5);
            Assert.AreEqual(6, mid.Socket6);
            Assert.AreEqual(7, mid.Socket7);
            Assert.AreEqual(1, mid.Socket8);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
