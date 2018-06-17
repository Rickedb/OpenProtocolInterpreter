using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0503 : MidTester
    {
        [TestMethod]
        public void Mid0503Revision1()
        {
            string package = "00200503            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0503), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
