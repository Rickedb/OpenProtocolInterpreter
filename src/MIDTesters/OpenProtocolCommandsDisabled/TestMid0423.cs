using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    public class TestMid0423 : MidTester
    {
        [TestMethod]
        public void Mid0423Revision1()
        {
            string package = "00200423            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0423), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
