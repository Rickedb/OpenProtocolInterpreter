using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0260 : MidTester
    {
        [TestMethod]
        public void Mid0260Revision1()
        {
            string package = "00200260            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0260), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
