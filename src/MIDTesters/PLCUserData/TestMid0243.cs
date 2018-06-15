using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0243 : MidTester
    {
        [TestMethod]
        public void Mid0243Revision1()
        {
            string package = "00200243            ";
            var mid = _midInterpreter.Parse<MID_0243>(package);

            Assert.AreEqual(typeof(MID_0243), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
