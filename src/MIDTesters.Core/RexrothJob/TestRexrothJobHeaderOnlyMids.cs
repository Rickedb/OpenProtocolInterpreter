using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.RexrothJob;

namespace MIDTesters.RexrothJob
{
    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0554 : DefaultMidTests<Mid0554>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0554Revision1()
        {
            string package = "00200554            ";
            var mid = _midInterpreter.Parse(package);
            Assert.AreEqual(typeof(Mid0554), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0554ByteRevision1()
        {
            string package = "00200554            ";
            var mid = _midInterpreter.Parse(GetAsciiBytes(package));
            Assert.AreEqual(typeof(Mid0554), mid.GetType());
            AssertEqualPackages(GetAsciiBytes(package), mid, true);
        }
    }

    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0556 : DefaultMidTests<Mid0556>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0556Revision1()
        {
            string package = "00200556            ";
            var mid = _midInterpreter.Parse(package);
            Assert.AreEqual(typeof(Mid0556), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0556ByteRevision1()
        {
            string package = "00200556            ";
            var mid = _midInterpreter.Parse(GetAsciiBytes(package));
            Assert.AreEqual(typeof(Mid0556), mid.GetType());
            AssertEqualPackages(GetAsciiBytes(package), mid, true);
        }
    }

    [TestClass]
    [TestCategory("RexrothJob")]
    public class TestMid0557 : DefaultMidTests<Mid0557>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0557Revision1()
        {
            string package = "00200557            ";
            var mid = _midInterpreter.Parse(package);
            Assert.AreEqual(typeof(Mid0557), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0557ByteRevision1()
        {
            string package = "00200557            ";
            var mid = _midInterpreter.Parse(GetAsciiBytes(package));
            Assert.AreEqual(typeof(Mid0557), mid.GetType());
            AssertEqualPackages(GetAsciiBytes(package), mid, true);
        }
    }
}
