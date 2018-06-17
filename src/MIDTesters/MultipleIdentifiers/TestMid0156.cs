using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0156 : MidTester
    {
        [TestMethod]
        public void Mid0156Revision1()
        {
            string package = "00200156            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0156), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
