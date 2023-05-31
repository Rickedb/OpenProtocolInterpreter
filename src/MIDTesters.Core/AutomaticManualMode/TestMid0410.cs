using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    [TestCategory("AutomaticManualMode")]
    public class TestMid0410 : DefaultMidTests<Mid0410>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0410Revision1()
        {
            string package = "00200410            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0410), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0410ByteRevision1()
        {
            string package = "00200410            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0410), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
