using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid2504 : MidTester
    {
        [TestMethod]
        public void Mid2504Revision1()
        {
            string package = "00232504001         010";
            var mid = _midInterpreter.Parse<Mid2504>(package);

            Assert.AreEqual(typeof(Mid2504), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid2504ByteRevision1()
        {
            string package = "00232504001         010";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid2504>(bytes);

            Assert.AreEqual(typeof(Mid2504), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
