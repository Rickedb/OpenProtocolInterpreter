using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0074 : MidTester
    {
        [TestMethod]
        public void Mid0074AllRevisions()
        {
            string pack = @"00240074001         E851";
            var mid = _midInterpreter.Parse<Mid0074>(pack);

            Assert.AreEqual(typeof(Mid0074), mid.GetType());
            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
