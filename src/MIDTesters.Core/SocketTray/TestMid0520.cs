using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.SocketTray;

namespace MIDTesters.SocketTray
{
    [TestClass]
    [TestCategory("SocketTray")]
    public class TestMid0520 : DefaultMidTests<Mid0520>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0520Revision1()
        {
            string package = "00200520            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0520), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0520ByteRevision1()
        {
            string package = "00200520            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0520), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
