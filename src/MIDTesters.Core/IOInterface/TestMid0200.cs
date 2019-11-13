using System;
using System.Linq;
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
            var mid = _midInterpreter.Parse<Mid0200>(package);

            Assert.AreEqual(typeof(Mid0200), mid.GetType());
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

        [TestMethod]
        public void Mid0200ByteRevision1()
        {
            string package = "00300200            1231231230";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0200>(bytes);

            Assert.AreEqual(typeof(Mid0200), mid.GetType());
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
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
