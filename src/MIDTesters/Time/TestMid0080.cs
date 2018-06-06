using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    public class TestMid0080 : MidTester
    {
        [TestMethod]
        public void Mid0080AllRevisions()
        {
            string pack = @"00200080            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(MID_0080), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
