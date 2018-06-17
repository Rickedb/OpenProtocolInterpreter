using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0125 : MidTester
    {
        [TestMethod]
        public void Mid0125Revision1()
        {
            string package = "00200125            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0125), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
