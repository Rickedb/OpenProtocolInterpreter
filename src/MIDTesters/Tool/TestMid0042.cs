using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0042 : MidTester
    {
        [TestMethod]
        public void Mid0042AllRevisions()
        {
            string package = "00200042            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0042), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
