using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0045 : MidTester
    {
        [TestMethod]
        public void Mid0045Revision1()
        {
            string package = "00310045            01402003000";
            var mid = _midInterpreter.Parse<Mid0045>(package);

            Assert.AreEqual(typeof(Mid0045), mid.GetType());
            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0045ByteRevision1()
        {
            string package = "00310045            01402003000";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0045>(bytes);

            Assert.AreEqual(typeof(Mid0045), mid.GetType());
            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0045Revision2()
        {
            string package = "00350045002         014020030000301";
            var mid = _midInterpreter.Parse<Mid0045>(package);

            Assert.AreEqual(typeof(Mid0045), mid.GetType());
            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.ChannelNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0045ByteRevision2()
        {
            string package = "00350045002         014020030000302";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0045>(bytes);

            Assert.AreEqual(typeof(Mid0045), mid.GetType());
            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.IsNotNull(mid.ChannelNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
