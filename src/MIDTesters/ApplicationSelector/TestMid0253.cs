using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    public class TestMid0253 : MidTester
    {
        [TestMethod]
        public void Mid0253Revision1()
        {
            string package = "00200253            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0253), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
