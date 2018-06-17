using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0244 : MidTester
    {
        [TestMethod]
        public void Mid0244Revision1()
        {
            string package = "00200244            ";
            var mid = _midInterpreter.Parse<Mid0244>(package);

            Assert.AreEqual(typeof(Mid0244), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
