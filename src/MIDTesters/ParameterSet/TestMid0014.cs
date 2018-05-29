using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0014 : MidTester
    {
        [TestMethod]
        public void Mid0014Revision1()
        {
            string package = "00200014            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0014), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
