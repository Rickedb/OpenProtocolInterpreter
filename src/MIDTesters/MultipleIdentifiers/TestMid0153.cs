using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0153 : MidTester
    {
        [TestMethod]
        public void Mid0153Revision1()
        {
            string package = "00200153            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0153), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
