using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0133 : MidTester
    {
        [TestMethod]
        public void Mid0133Revision1()
        {
            string package = "00200133            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0133), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
