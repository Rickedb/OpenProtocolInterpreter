using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0051 : MidTester
    {
        [TestMethod]
        public void Mid0051AllRevisions()
        {
            string package = "002000510010        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0051), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
