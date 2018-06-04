using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0039 : MidTester
    {
        [TestMethod]
        public void Mid0039Revision1()
        {
            string package = "00220039001         01";
            var mid = _midInterpreter.Parse<MID_0039>(package);

            Assert.AreEqual(typeof(MID_0039), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0039Revision2()
        {
            string package = "00240039002         0003";
            var mid = _midInterpreter.Parse<MID_0039>(package);

            Assert.AreEqual(typeof(MID_0039), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
