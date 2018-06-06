using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    public class TestMid0082 : MidTester
    {
        [TestMethod]
        public void Mid0082Revision1()
        {
            string pack = @"00390082            2017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<MID_0082>(pack);

            Assert.AreEqual(typeof(MID_0082), mid.GetType());
            Assert.IsNotNull(mid.Time);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
