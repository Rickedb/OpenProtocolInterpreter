using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0220 : MidTester
    {
        [TestMethod]
        public void Mid0220Revision1()
        {
            string package = "00230220            120";
            var mid = _midInterpreter.Parse<MID_0220>(package);

            Assert.AreEqual(typeof(MID_0220), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
