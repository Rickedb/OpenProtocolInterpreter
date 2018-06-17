using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0265 : MidTester
    {
        [TestMethod]
        public void Mid0265Revision1()
        {
            string package = "003402650011        013200078D0202";
            var mid = _midInterpreter.Parse<Mid0265>(package);

            Assert.AreEqual(typeof(Mid0265), mid.GetType());
            Assert.IsNotNull(mid.ToolTagId);
            Assert.IsNotNull(mid.ToolStatus);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
