using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0078 : MidTester
    {
        [TestMethod]
        public void Mid0078AllRevisions()
        {
            string pack = @"00200078            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(MID_0078), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
