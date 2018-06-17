using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0410 : MidTester
    {
        [TestMethod]
        public void Mid0410Revision1()
        {
            string package = "00200410            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0410), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
