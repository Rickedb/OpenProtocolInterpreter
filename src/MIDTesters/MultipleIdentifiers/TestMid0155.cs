using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0155 : MidTester
    {
        [TestMethod]
        public void Mid0155Revision1()
        {
            string package = "00200155            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0155), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
