using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0200 : MidTester
    {
        [TestMethod]
        public void Mid0200Revision1()
        {
            string package = "00300200            1231231230";
            var mid = _midInterpreter.Parse<MID_0200>(package);

            Assert.AreEqual(typeof(MID_0200), mid.GetType());
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
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
