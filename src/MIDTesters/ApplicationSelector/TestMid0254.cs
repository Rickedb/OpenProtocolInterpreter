using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    public class TestMid0254 : MidTester
    {
        [TestMethod]
        public void Mid0254Revision1()
        {
            string package = "00340254            01110201221022";
            var mid = _midInterpreter.Parse<Mid0254>(package);

            Assert.AreEqual(typeof(Mid0254), mid.GetType());
            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.GreenLights);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
