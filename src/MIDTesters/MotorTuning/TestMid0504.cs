using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0504 : MidTester
    {
        [TestMethod]
        public void Mid0504Revision1()
        {
            string package = "00200504            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0504), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
