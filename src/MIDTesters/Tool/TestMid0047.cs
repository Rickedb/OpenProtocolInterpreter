using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0047 : MidTester
    {
        [TestMethod]
        public void Mid0047Revision1()
        {
            string package = "00240047001         0103";
            var mid = _midInterpreter.Parse<MID_0047>(package);

            Assert.AreEqual(typeof(MID_0047), mid.GetType());
            Assert.IsNotNull(mid.PairingHandlingType);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
