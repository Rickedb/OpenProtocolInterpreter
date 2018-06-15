using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    public class TestMid0255 : MidTester
    {
        [TestMethod]
        public void Mid0255Revision1()
        {
            string package = "00340255            01510221112022";
            var mid = _midInterpreter.Parse<MID_0255>(package);

            Assert.AreEqual(typeof(MID_0255), mid.GetType());
            Assert.IsNotNull(mid.DeviceId);
            Assert.IsNotNull(mid.RedLights);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
