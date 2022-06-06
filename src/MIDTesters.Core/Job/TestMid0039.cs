﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0039 : DefaultMidTests<Mid0039>
    {
        [TestMethod]
        public void Mid0039Revision1()
        {
            string package = "00220039001         01";
            var mid = _midInterpreter.Parse<Mid0039>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0039ByteRevision1()
        {
            string package = "00220039001         01";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0039>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        public void Mid0039Revision2()
        {
            string package = "00240039002         0003";
            var mid = _midInterpreter.Parse<Mid0039>(package);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0039ByteRevision2()
        {
            string package = "00240039002         0003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0039>(bytes);

            Assert.IsNotNull(mid.JobId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
