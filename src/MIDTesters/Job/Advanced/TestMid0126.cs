using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0126 : MidTester
    {
        [TestMethod]
        public void Mid0126Revision1()
        {
            string package = "00200126            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0126), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
