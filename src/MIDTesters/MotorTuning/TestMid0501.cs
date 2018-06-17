using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0501 : MidTester
    {
        [TestMethod]
        public void Mid0501Revision1()
        {
            string package = "00230501            011";
            var mid = _midInterpreter.Parse<MID_0501>(package);

            Assert.AreEqual(typeof(MID_0501), mid.GetType());
            Assert.IsNotNull(mid.MotorTuneResult);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
