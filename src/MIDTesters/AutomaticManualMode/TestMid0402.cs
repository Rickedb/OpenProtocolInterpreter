using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0402 : MidTester
    {
        [TestMethod]
        public void Mid0402Revision1()
        {
            string package = "00200402            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0402), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
