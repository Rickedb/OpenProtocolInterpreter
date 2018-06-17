using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    public class TestMid0421 : MidTester
    {
        [TestMethod]
        public void Mid0421Revision1()
        {
            string package = "00210421   1        1";
            var mid = _midInterpreter.Parse<Mid0421>(package);

            Assert.AreEqual(typeof(Mid0421), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsNotNull(mid.DigitalInputStatus);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
