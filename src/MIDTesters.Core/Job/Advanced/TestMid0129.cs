using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0129 : MidTester
    {
        [TestMethod]
        public void Mid0129Revision1()
        {
            string package = "00200129            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0129ByteRevision1()
        {
            string package = "00200129            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0129Revision2()
        {
            string package = "00290129002         010302123";
            var mid = _midInterpreter.Parse<Mid0129>(package);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0129ByteRevision2()
        {
            string package = "00290129002         010302123";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0129>(bytes);

            Assert.AreEqual(typeof(Mid0129), mid.GetType());
            Assert.IsNotNull(mid.ChannelId);
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
