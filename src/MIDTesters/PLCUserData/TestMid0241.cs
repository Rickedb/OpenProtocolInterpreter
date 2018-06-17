using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0241 : MidTester
    {
        [TestMethod]
        public void Mid0241Revision1()
        {
            string package = "00200241   1        ";
            var mid = _midInterpreter.Parse<Mid0241>(package);

            Assert.AreEqual(typeof(Mid0241), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
