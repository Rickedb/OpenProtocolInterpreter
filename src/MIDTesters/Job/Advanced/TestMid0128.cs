using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0128 : MidTester
    {
        [TestMethod]
        public void Mid0128Revision1()
        {
            string package = "00200128            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0128), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
