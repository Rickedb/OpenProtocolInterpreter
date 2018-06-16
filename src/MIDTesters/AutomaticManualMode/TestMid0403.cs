using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0403 : MidTester
    {
        [TestMethod]
        public void Mid0403Revision1()
        {
            string package = "00200403            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0403), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
