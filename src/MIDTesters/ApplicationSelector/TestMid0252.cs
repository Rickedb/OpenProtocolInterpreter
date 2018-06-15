using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    public class TestMid0252 : MidTester
    {
        [TestMethod]
        public void Mid0252Revision1()
        {
            string package = "00200252            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0252), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
