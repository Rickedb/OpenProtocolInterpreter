using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

using System.Collections.Generic;
using OpenProtocolInterpreter;
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

            Assert.AreEqual(3, mid.IODeviceId);
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

            Assert.AreEqual(3, mid.IODeviceId);
            Assert.AreEqual(8, mid.Relays.Count);
            Assert.AreEqual(8, mid.DigitalInputs.Count);

            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0215Revision2()
        {
            string package = @"00920215002         010302070300100021003100400051006000710407050011002000310041005100610070";
            var mid = _midInterpreter.Parse<Mid0215>(package);

            Assert.AreEqual(3, mid.IODeviceId);
            Assert.AreEqual(7, mid.NumberOfRelays);
            Assert.AreEqual(7, mid.Relays.Count);
            Assert.AreEqual(7, mid.NumberOfDigitalInputs);
            Assert.AreEqual(7, mid.DigitalInputs.Count);

            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0215ByteRevision2()
        {
            string package = "00920215002         010302070300100021003100400051006000710407050011002000310041005100610070";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0215>(bytes);

            Assert.AreEqual(3, mid.IODeviceId);
            Assert.AreEqual(7, mid.Relays.Count);
            Assert.AreEqual(7, mid.DigitalInputs.Count);
            Assert.AreEqual(7, mid.NumberOfRelays);
            Assert.AreEqual(7, mid.NumberOfDigitalInputs);

            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0215PackRevision1()
        {
            string package = "00920215001         010302001000210031004010012000300140010300110020003100410051006100700080";

            AssertBuildAndParse(package, new Mid0215(1)
            {
                IODeviceId = 3,
                Relays = new List<Relay>()
                {
                    new Relay(RelayNumber.Ok, false),
                    new Relay(RelayNumber.Nok, true),
                    new Relay(RelayNumber.Low, true),
                    new Relay(RelayNumber.High, false),
                    new Relay(RelayNumber.ExternalControlled8, true),
                    new Relay((RelayNumber)200, false),
                    new Relay(RelayNumber.TrackingDisabled, true),
                    new Relay((RelayNumber)400, true)
                },
                DigitalInputs = new List<DigitalInput>()
                {
                    new DigitalInput(DigitalInputNumber.ResetBatch, true),
                    new DigitalInput(DigitalInputNumber.UnlockTool, false),
                    new DigitalInput(DigitalInputNumber.ToolDisableNo, true),
                    new DigitalInput(DigitalInputNumber.ToolDisableNc, true),
                    new DigitalInput(DigitalInputNumber.ToolTighteningDisable, true),
                    new DigitalInput(DigitalInputNumber.ToolLooseningDisable, true),
                    new DigitalInput(DigitalInputNumber.RemoteStartPulse, false),
                    new DigitalInput(DigitalInputNumber.RemoteStartCont, false)
                }
            });
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0215PackRevision2()
        {
            string package = @"00920215002         010302070300100021003100400051006000710407050011002000310041005100610070";

            AssertBuildAndParse(package, new Mid0215(2)
            {
                IODeviceId = 3,
                NumberOfRelays = 7,
                Relays = new List<Relay>()
                {
                    new Relay(RelayNumber.Ok, false),
                    new Relay(RelayNumber.Nok, true),
                    new Relay(RelayNumber.Low, true),
                    new Relay(RelayNumber.High, false),
                    new Relay(RelayNumber.LowTorque, true),
                    new Relay(RelayNumber.HighTorque, false),
                    new Relay(RelayNumber.LowAngle, true)
                },
                NumberOfDigitalInputs = 7,
                DigitalInputs = new List<DigitalInput>()
                {
                    new DigitalInput(DigitalInputNumber.ResetBatch, true),
                    new DigitalInput(DigitalInputNumber.UnlockTool, false),
                    new DigitalInput(DigitalInputNumber.ToolDisableNo, true),
                    new DigitalInput(DigitalInputNumber.ToolDisableNc, true),
                    new DigitalInput(DigitalInputNumber.ToolTighteningDisable, true),
                    new DigitalInput(DigitalInputNumber.ToolLooseningDisable, true),
                    new DigitalInput(DigitalInputNumber.RemoteStartPulse, false)
                }
            });
        }
    }
}
