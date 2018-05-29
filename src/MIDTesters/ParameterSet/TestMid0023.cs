using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0023 : MidTester
    {
        [TestMethod]
        public void Mid0023Revision1()
        {
            string package = "00200023            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0023), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
