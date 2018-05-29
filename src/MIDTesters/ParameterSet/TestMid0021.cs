using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0021 : MidTester
    {
        [TestMethod]
        public void Mid0021Revision1()
        {
            string package = "00200021   0        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0021), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
