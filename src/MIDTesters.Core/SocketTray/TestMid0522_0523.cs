using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.SocketTray;

namespace MIDTesters.SocketTray
{
    [TestClass]
    [TestCategory("SocketTray")]
    public class TestMid0522 : DefaultMidTests<Mid0522>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0522Revision1()
        {
            string package = "00200522            ";
            var mid = _midInterpreter.Parse(package);
            Assert.AreEqual(typeof(Mid0522), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0522ByteRevision1()
        {
            string package = "00200522            ";
            var mid = _midInterpreter.Parse(GetAsciiBytes(package));
            Assert.AreEqual(typeof(Mid0522), mid.GetType());
            AssertEqualPackages(GetAsciiBytes(package), mid, true);
        }
    }

    [TestClass]
    [TestCategory("SocketTray")]
    public class TestMid0523 : DefaultMidTests<Mid0523>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0523Revision1()
        {
            string package = "00200523            ";
            var mid = _midInterpreter.Parse(package);
            Assert.AreEqual(typeof(Mid0523), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0523ByteRevision1()
        {
            string package = "00200523            ";
            var mid = _midInterpreter.Parse(GetAsciiBytes(package));
            Assert.AreEqual(typeof(Mid0523), mid.GetType());
            AssertEqualPackages(GetAsciiBytes(package), mid, true);
        }
    }
}
