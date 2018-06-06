using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0072 : MidTester
    {
        [TestMethod]
        public void Mid0072AllRevisions()
        {
            string pack = @"00200072002         ";
            var mid = _midInterpreter.Parse<MID_0072>(pack);

            Assert.AreEqual(typeof(MID_0072), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
