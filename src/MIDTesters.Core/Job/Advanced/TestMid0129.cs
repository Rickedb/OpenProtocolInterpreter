﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0129 : DefaultMidTests<Mid0129>
    {
        [TestMethod]
        public void Mid0129Revision1()
        {
            string package = "00200129            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0129ByteRevision1()
        {
            string package = "00200129            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        public void Mid0129Revision2()
        {
            string package = "00290129002         010302123";
            var mid = _midInterpreter.Parse<Mid0129>(package);

            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0129ByteRevision2()
        {
            string package = "00290129002         010302123";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0129>(bytes);

            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
