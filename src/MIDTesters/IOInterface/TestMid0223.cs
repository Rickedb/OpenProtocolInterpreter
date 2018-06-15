using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0223 : MidTester
    {
        [TestMethod]
        public void Mid0223Revision1()
        {
            string package = "00230223            066";
            var mid = _midInterpreter.Parse<MID_0223>(package);

            Assert.AreEqual(typeof(MID_0223), mid.GetType());
            Assert.IsNotNull(mid.DigitalInputNumber);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
