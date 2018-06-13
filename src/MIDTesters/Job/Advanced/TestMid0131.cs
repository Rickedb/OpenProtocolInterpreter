using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0131 : MidTester
    {
        [TestMethod]
        public void Mid0131Revision1()
        {
            string package = "00200131            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0131), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
