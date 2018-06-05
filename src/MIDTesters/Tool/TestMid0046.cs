using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0046 : MidTester
    {
        [TestMethod]
        public void Mid0046Revision1()
        {
            string package = "00240046001         0102";
            var mid = _midInterpreter.Parse<MID_0046>(package);

            Assert.AreEqual(typeof(MID_0046), mid.GetType());
            Assert.IsNotNull(mid.PrimaryTool);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
