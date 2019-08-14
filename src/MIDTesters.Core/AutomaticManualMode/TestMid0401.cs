using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0401 : MidTester
    {
        [TestMethod]
        public void Mid0401Revision1()
        {
            string package = "00210401   1        1";
            var mid = _midInterpreter.Parse<Mid0401>(package);

            Assert.AreEqual(typeof(Mid0401), mid.GetType());
            Assert.IsNotNull(mid.ManualAutomaticMode);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0401ByteRevision1()
        {
            string package = "00210401   1        1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0401>(bytes);

            Assert.AreEqual(typeof(Mid0401), mid.GetType());
            Assert.IsNotNull(mid.ManualAutomaticMode);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
