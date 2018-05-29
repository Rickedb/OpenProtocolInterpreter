using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0017 : MidTester
    {
        [TestMethod]
        public void Mid0017Revision1()
        {
            string package = "00200017            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0017), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
