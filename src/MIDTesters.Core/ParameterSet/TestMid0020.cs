using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0020 : MidTester
    {
        [TestMethod]
        public void Mid0020Revision1()
        {
            string package = "00230020            054";
            var mid = _midInterpreter.Parse<Mid0020>(package);

            Assert.AreEqual(typeof(Mid0020), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0020ByteRevision1()
        {
            string package = "00230020            054";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0020>(bytes);

            Assert.AreEqual(typeof(Mid0020), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
