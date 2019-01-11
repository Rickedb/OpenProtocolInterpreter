using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0215 : MidTester
    {
        [TestMethod]
        public void Mid0215Revision1()
        {
            string package = "00920215001         010302001000210031004010012000300140010300110020003100410051006100700080";
            var mid = _midInterpreter.Parse<Mid0215>(package);

            Assert.AreEqual(typeof(Mid0215), mid.GetType());
            Assert.IsNotNull(mid.IODeviceId);
            Assert.IsNotNull(mid.Relays);
            Assert.IsNotNull(mid.DigitalInputs);
            Assert.AreEqual(8, mid.Relays.Count);
            Assert.AreEqual(8, mid.DigitalInputs.Count);

            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0215Revision2()
        {
            string package = "00920215002         010302070300100021003100400051006000710407050011002000310041005100610070";
            var mid = _midInterpreter.Parse<Mid0215>(package);

            Assert.AreEqual(typeof(Mid0215), mid.GetType());
            Assert.IsNotNull(mid.IODeviceId);
            Assert.IsNotNull(mid.Relays);
            Assert.IsNotNull(mid.DigitalInputs);
            Assert.AreEqual(7, mid.Relays.Count);
            Assert.AreEqual(7, mid.DigitalInputs.Count);

            Assert.IsNotNull(mid.NumberOfDigitalInputs);
            Assert.IsNotNull(mid.NumberOfRelays);
        }
    }
}
