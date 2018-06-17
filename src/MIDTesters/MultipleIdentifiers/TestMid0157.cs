using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0157 : MidTester
    {
        [TestMethod]
        public void Mid0157Revision1()
        {
            string package = "00200157            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0157), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
