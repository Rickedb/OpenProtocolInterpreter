using System;
using System.Linq;
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
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0032ByteRevision1()
        {
            string package = "00220032001         04";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0032Revision2()
        {
            string package = "00240032002         0002";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0032ByteRevision2()
        {
            string package = "00240032002         0002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0032Revision3()
        {
            string package = "00240032003         0003";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0032ByteRevision3()
        {
            string package = "00240032003         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0032Revision4()
        {
            string package = "00240032004         0003";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0032ByteRevision4()
        {
            string package = "00240032004         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.AreEqual(typeof(Mid0032), mid.GetType());
            Assert.IsNotNull(mid.JobId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
