using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MotorTuning;

namespace MIDTesters.MotorTuning
{
    [TestClass]
    public class TestMid0501 : MidTester
    {
        [TestMethod]
        public void Mid0501Revision1()
        {
            string package = "00230501            011";
            var mid = _midInterpreter.Parse<Mid0501>(package);

            Assert.AreEqual(typeof(Mid0501), mid.GetType());
            Assert.IsNotNull(mid.MotorTuneResult);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0501ByteRevision1()
        {
            string package = "00230501            011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0501>(bytes);

            Assert.AreEqual(typeof(Mid0501), mid.GetType());
            Assert.IsNotNull(mid.MotorTuneResult);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
