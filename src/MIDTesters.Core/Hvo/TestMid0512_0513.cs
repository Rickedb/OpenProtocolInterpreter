using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Hvo;

namespace MIDTesters.Hvo
{
    [TestClass]
    [TestCategory("Hvo")]
    public class TestMid0512 : DefaultMidTests<Mid0512>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0512Revision1()
        {
            string package = "00200512            ";
            var mid = _midInterpreter.Parse(package);
            Assert.AreEqual(typeof(Mid0512), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0512ByteRevision1()
        {
            string package = "00200512            ";
            var mid = _midInterpreter.Parse(GetAsciiBytes(package));
            Assert.AreEqual(typeof(Mid0512), mid.GetType());
            AssertEqualPackages(GetAsciiBytes(package), mid, true);
        }
    }

    [TestClass]
    [TestCategory("Hvo")]
    public class TestMid0513 : DefaultMidTests<Mid0513>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0513Revision1()
        {
            string package = "00200513            ";
            var mid = _midInterpreter.Parse(package);
            Assert.AreEqual(typeof(Mid0513), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0513ByteRevision1()
        {
            string package = "00200513            ";
            var mid = _midInterpreter.Parse(GetAsciiBytes(package));
            Assert.AreEqual(typeof(Mid0513), mid.GetType());
            AssertEqualPackages(GetAsciiBytes(package), mid, true);
        }
    }
}
