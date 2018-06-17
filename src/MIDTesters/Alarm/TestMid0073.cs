using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0073 : MidTester
    {
        [TestMethod]
        public void Mid0073AllRevisions()
        {
            string pack = @"00200073002         ";
            var mid = _midInterpreter.Parse<Mid0073>(pack);

            Assert.AreEqual(typeof(Mid0073), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
