using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0502 : MidTester
    {
        [TestMethod]
        public void Mid0502Revision1()
        {
            string package = "00200502            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0502), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
