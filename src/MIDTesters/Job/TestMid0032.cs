using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0032 : MidTester
    {
        [TestMethod]
        public void Mid0032Revision1()
        {
            string package = "00220032001         04";
            var mid = _midInterpreter.Parse<MID_0032>(package);

            Assert.AreEqual(typeof(MID_0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0032Revision2()
        {
            string package = "00240032002         0002";
            var mid = _midInterpreter.Parse<MID_0032>(package);

            Assert.AreEqual(typeof(MID_0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0032Revision3()
        {
            string package = "00240032003         0003";
            var mid = _midInterpreter.Parse<MID_0032>(package);

            Assert.AreEqual(typeof(MID_0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
