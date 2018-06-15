using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0221 : MidTester
    {
        [TestMethod]
        public void Mid0221Revision1()
        {
            string package = "00280221            01120021";
            var mid = _midInterpreter.Parse<MID_0221>(package);

            Assert.AreEqual(typeof(MID_0221), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.IsNotNull(mid.DigitalInputStatus);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
