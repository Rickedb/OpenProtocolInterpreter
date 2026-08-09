using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0220 : DefaultMidTests<Mid0220>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0220Revision1()
        {
            string package = "00230220            120";
            var mid = _midInterpreter.Parse<Mid0220>(package);

            Assert.AreEqual(DigitalInputNumber.ForcedCcwOnce, mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0220ByteRevision1()
        {
            string package = "00230220            120";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0220>(bytes);

            Assert.AreEqual(DigitalInputNumber.ForcedCcwOnce, mid.DigitalInputNumber);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0220PackRevision1()
        {
            string package = "00230220            120";

            AssertBuildAndParse(package, new Mid0220()
            {
                DigitalInputNumber = DigitalInputNumber.ForcedCcwOnce
            }, true);
        }
    }
}
