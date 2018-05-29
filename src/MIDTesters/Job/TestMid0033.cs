using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0033 : MidTester
    {
        //[TestMethod]
        public void Mid0032Revision1()
        {
            string package = "00220032001         04";
            var mid = _midInterpreter.Parse<MID_0033>(package);

            Assert.AreEqual(typeof(MID_0033), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
