using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0215 : DefaultMidTests<Mid0215>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0215Revision1()
        {
            string package = "00920215001         010302001000210031004010012000300140010300110020003100410051006100700080";
            var mid = _midInterpreter.Parse<Mid0215>(package);

            Assert.IsNotNull(mid.IODeviceId);
            Assert.IsNotNull(mid.Relays);
            Assert.IsNotNull(mid.DigitalInputs);
            Assert.AreEqual(8, mid.Relays.Count);
            Assert.AreEqual(8, mid.DigitalInputs.Count);

            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0215ByteRevision1()
        {
            string package = "00920215001         010302001000210031004010012000300140010300110020003100410051006100700080";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0215>(bytes);

            Assert.IsNotNull(mid.IODeviceId);
            Assert.IsNotNull(mid.Relays);
            Assert.IsNotNull(mid.DigitalInputs);
            Assert.AreEqual(8, mid.Relays.Count);
            Assert.AreEqual(8, mid.DigitalInputs.Count);

            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0215Revision2()
        {
            string package = "00920215002         010302070300100021003100400051006000710407050011002000310041005100610070";
            var mid = _midInterpreter.Parse<Mid0215>(package);

            Assert.IsNotNull(mid.IODeviceId);
            Assert.IsNotNull(mid.Relays);
            Assert.IsNotNull(mid.DigitalInputs);
            Assert.AreEqual(7, mid.Relays.Count);
            Assert.AreEqual(7, mid.DigitalInputs.Count);

            Assert.IsNotNull(mid.NumberOfDigitalInputs);
            Assert.IsNotNull(mid.NumberOfRelays);

            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0215ByteRevision2()
        {
            string package = "00920215002         010302070300100021003100400051006000710407050011002000310041005100610070";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0215>(bytes);

            Assert.IsNotNull(mid.IODeviceId);
            Assert.IsNotNull(mid.Relays);
            Assert.IsNotNull(mid.DigitalInputs);
            Assert.AreEqual(7, mid.Relays.Count);
            Assert.AreEqual(7, mid.DigitalInputs.Count);

            Assert.IsNotNull(mid.NumberOfDigitalInputs);
            Assert.IsNotNull(mid.NumberOfRelays);

            AssertEqualPackages(bytes, mid);
        }
    }
}
