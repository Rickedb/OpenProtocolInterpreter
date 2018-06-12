using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0130 : MidTester
    {
        [TestMethod]
        public void Mid0130Revision1()
        {
            string package = "00210130            1";
            var mid = _midInterpreter.Parse<MID_0130>(package);

            Assert.AreEqual(typeof(MID_0130), mid.GetType());
            Assert.IsNotNull(mid.JobOffStatus);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
