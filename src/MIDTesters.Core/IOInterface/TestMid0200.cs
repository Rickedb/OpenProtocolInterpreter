using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0200 : DefaultMidTests<Mid0200>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0200Revision1()
        {
            string package = "00300200            1231231230";
            var mid = _midInterpreter.Parse<Mid0200>(package);

            Assert.IsNotNull(mid.StatusRelayOne);
            Assert.IsNotNull(mid.StatusRelayTwo);
            Assert.IsNotNull(mid.StatusRelayThree);
            Assert.IsNotNull(mid.StatusRelayFour);
            Assert.IsNotNull(mid.StatusRelayFive);
            Assert.IsNotNull(mid.StatusRelaySix);
            Assert.IsNotNull(mid.StatusRelaySeven);
            Assert.IsNotNull(mid.StatusRelayEight);
            Assert.IsNotNull(mid.StatusRelayNine);
            Assert.IsNotNull(mid.StatusRelayTen);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0200ByteRevision1()
        {
            string package = "00300200            1231231230";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0200>(bytes);

            Assert.IsNotNull(mid.StatusRelayOne);
            Assert.IsNotNull(mid.StatusRelayTwo);
            Assert.IsNotNull(mid.StatusRelayThree);
            Assert.IsNotNull(mid.StatusRelayFour);
            Assert.IsNotNull(mid.StatusRelayFive);
            Assert.IsNotNull(mid.StatusRelaySix);
            Assert.IsNotNull(mid.StatusRelaySeven);
            Assert.IsNotNull(mid.StatusRelayEight);
            Assert.IsNotNull(mid.StatusRelayNine);
            Assert.IsNotNull(mid.StatusRelayTen);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
