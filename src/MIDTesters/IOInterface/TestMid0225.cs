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
            var mid = _midInterpreter.Parse<Mid0225>(package);

            Assert.AreEqual(typeof(Mid0225), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
