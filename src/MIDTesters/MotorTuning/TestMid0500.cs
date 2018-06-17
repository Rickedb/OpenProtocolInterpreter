using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0500 : MidTester
    {
        [TestMethod]
        public void Mid0500Revision1()
        {
            string package = "00200500            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0500), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
