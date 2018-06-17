using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0400 : MidTester
    {
        [TestMethod]
        public void Mid0400Revision1()
        {
            string package = "00200400   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0400), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
