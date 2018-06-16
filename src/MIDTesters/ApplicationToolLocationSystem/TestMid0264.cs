using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0264 : MidTester
    {
        [TestMethod]
        public void Mid0264Revision1()
        {
            string package = "00200264            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0264), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
