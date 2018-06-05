using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0043 : MidTester
    {
        [TestMethod]
        public void Mid0043AllRevisions()
        {
            string package = "00200043            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0043), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
