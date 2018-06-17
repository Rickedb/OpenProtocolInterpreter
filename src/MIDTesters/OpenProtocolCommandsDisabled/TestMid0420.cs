using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.OpenProtocolCommandsDisabled;

namespace MIDTesters.OpenProtocolCommandsDisabled
{
    [TestClass]
    public class TestMid0420 : MidTester
    {
        [TestMethod]
        public void Mid0420Revision1()
        {
            string package = "00200420   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0420), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
