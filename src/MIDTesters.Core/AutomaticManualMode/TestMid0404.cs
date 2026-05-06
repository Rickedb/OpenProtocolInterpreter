using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    [TestCategory("AutomaticManualMode")]
    public class TestMid0404 : DefaultMidTests<Mid0404>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0404Revision1()
        {
            string package = "00210404            1";
            var mid = _midInterpreter.Parse<Mid0404>(package);

            Assert.IsTrue(mid.ManualAutomaticMode);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0404ByteRevision1()
        {
            string package = "00210404            1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0404>(bytes);

            Assert.IsTrue(mid.ManualAutomaticMode);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0404Revision1AutomaticMode()
        {
            string package = "00210404            0";
            var mid = _midInterpreter.Parse<Mid0404>(package);

            Assert.IsFalse(mid.ManualAutomaticMode);
            AssertEqualPackages(package, mid, true);
        }
    }
}
