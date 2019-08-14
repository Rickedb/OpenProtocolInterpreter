using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0018 : MidTester
    {
        [TestMethod]
        public void Mid0018Revision1()
        {
            string package = "00230018001         022";
            var mid = _midInterpreter.Parse<Mid0018>(package);

            Assert.AreEqual(typeof(Mid0018), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0018ByteRevision1()
        {
            string package = "00230018001         022";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0018>(bytes);

            Assert.AreEqual(typeof(Mid0018), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
