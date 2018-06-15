using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0225 : MidTester
    {
        [TestMethod]
        public void Mid0225Revision1()
        {
            string package = "00230225            055";
            var mid = _midInterpreter.Parse<MID_0225>(package);

            Assert.AreEqual(typeof(MID_0225), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
