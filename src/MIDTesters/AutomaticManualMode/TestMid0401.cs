using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0401 : MidTester
    {
        [TestMethod]
        public void Mid0401Revision1()
        {
            string package = "00210401   1        1";
            var mid = _midInterpreter.Parse<MID_0401>(package);

            Assert.AreEqual(typeof(MID_0401), mid.GetType());
            Assert.IsNotNull(mid.ManualAutomaticMode);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
