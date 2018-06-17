using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0045 : MidTester
    {
        [TestMethod]
        public void Mid0045AllRevisions()
        {
            string package = "00310045            01402003000";
            var mid = _midInterpreter.Parse<Mid0045>(package);

            Assert.AreEqual(typeof(Mid0045), mid.GetType());
            Assert.IsNotNull(mid.CalibrationValueUnit);
            Assert.IsNotNull(mid.CalibrationValue);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
