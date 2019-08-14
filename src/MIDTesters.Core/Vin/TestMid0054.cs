using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0054 : MidTester
    {
        [TestMethod]
        public void Mid0054AllRevisions()
        {
            string package = "00200054            ";
            var mid = _midInterpreter.Parse<Mid0054>(package);

            Assert.AreEqual(typeof(Mid0054), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
