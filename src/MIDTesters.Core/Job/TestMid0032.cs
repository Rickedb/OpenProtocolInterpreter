﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0032 : DefaultMidTests<Mid0032>
    {
        [TestMethod]
        public void Mid0032Revision1()
        {
            string package = "00220032001         04";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0032ByteRevision1()
        {
            string package = "00220032001         04";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0032Revision2()
        {
            string package = "00240032002         0002";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0032ByteRevision2()
        {
            string package = "00240032002         0002";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0032Revision3()
        {
            string package = "00240032003         0003";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0032ByteRevision3()
        {
            string package = "00240032003         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0032Revision4()
        {
            string package = "00240032004         0003";
            var mid = _midInterpreter.Parse<Mid0032>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0032ByteRevision4()
        {
            string package = "00240032004         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0032>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
