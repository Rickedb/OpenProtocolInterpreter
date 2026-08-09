using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;
using OpenProtocolInterpreter;

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

            Assert.AreEqual(RelayStatus.On, mid.StatusRelayOne);
            Assert.AreEqual(RelayStatus.Flashing, mid.StatusRelayTwo);
            Assert.AreEqual(RelayStatus.KeepCurrentStatus, mid.StatusRelayThree);
            Assert.AreEqual(RelayStatus.On, mid.StatusRelayFour);
            Assert.AreEqual(RelayStatus.Flashing, mid.StatusRelayFive);
            Assert.AreEqual(RelayStatus.KeepCurrentStatus, mid.StatusRelaySix);
            Assert.AreEqual(RelayStatus.On, mid.StatusRelaySeven);
            Assert.AreEqual(RelayStatus.Flashing, mid.StatusRelayEight);
            Assert.AreEqual(RelayStatus.KeepCurrentStatus, mid.StatusRelayNine);
            Assert.AreEqual(RelayStatus.Off, mid.StatusRelayTen);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0200ByteRevision1()
        {
            string package = "00300200            1231231230";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0200>(bytes);

            Assert.AreEqual(RelayStatus.On, mid.StatusRelayOne);
            Assert.AreEqual(RelayStatus.Flashing, mid.StatusRelayTwo);
            Assert.AreEqual(RelayStatus.KeepCurrentStatus, mid.StatusRelayThree);
            Assert.AreEqual(RelayStatus.On, mid.StatusRelayFour);
            Assert.AreEqual(RelayStatus.Flashing, mid.StatusRelayFive);
            Assert.AreEqual(RelayStatus.KeepCurrentStatus, mid.StatusRelaySix);
            Assert.AreEqual(RelayStatus.On, mid.StatusRelaySeven);
            Assert.AreEqual(RelayStatus.Flashing, mid.StatusRelayEight);
            Assert.AreEqual(RelayStatus.KeepCurrentStatus, mid.StatusRelayNine);
            Assert.AreEqual(RelayStatus.Off, mid.StatusRelayTen);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0200PackRevision1()
        {
            string package = "00300200            1231231230";

            AssertBuildAndParse(package, new Mid0200()
            {
                StatusRelayOne = RelayStatus.On,
                StatusRelayTwo = RelayStatus.Flashing,
                StatusRelayThree = RelayStatus.KeepCurrentStatus,
                StatusRelayFour = RelayStatus.On,
                StatusRelayFive = RelayStatus.Flashing,
                StatusRelaySix = RelayStatus.KeepCurrentStatus,
                StatusRelaySeven = RelayStatus.On,
                StatusRelayEight = RelayStatus.Flashing,
                StatusRelayNine = RelayStatus.KeepCurrentStatus,
                StatusRelayTen = RelayStatus.Off
            }, true);
        }
    }
}
