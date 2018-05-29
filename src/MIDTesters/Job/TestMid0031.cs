using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0031 : MidTester
    {
        [TestMethod]
        public void Mid0031Revision1()
        {
            string package = "00300031001         0401020304";
            var mid = _midInterpreter.Parse<MID_0031>(package);

            Assert.AreEqual(typeof(MID_0031), mid.GetType());
            Assert.IsNotNull(mid.TotalJobs);
            Assert.IsNotNull(mid.JobIds);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0031Revision2()
        {
            string package = "00640031002         00100001000200030004000500100015001100120019";
            var mid = _midInterpreter.Parse<MID_0031>(package);

            Assert.AreEqual(typeof(MID_0031), mid.GetType());
            Assert.IsNotNull(mid.TotalJobs);
            Assert.IsNotNull(mid.JobIds);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
