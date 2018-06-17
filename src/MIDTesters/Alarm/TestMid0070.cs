using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0070 : MidTester
    {
        [TestMethod]
        public void Mid0070AllRevisions()
        {
            string pack = @"002000700021        ";
            var mid = _midInterpreter.Parse<Mid0070>(pack);

            Assert.AreEqual(typeof(Mid0070), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
