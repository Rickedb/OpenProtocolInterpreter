using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0053 : MidTester
    {
        [TestMethod]
        public void Mid0053AllRevisions()
        {
            string package = "00200053001         ";
            var mid = _midInterpreter.Parse<Mid0053>(package);

            Assert.AreEqual(typeof(Mid0053), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
