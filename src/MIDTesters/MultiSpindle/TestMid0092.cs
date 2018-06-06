using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0092 : MidTester
    {
        [TestMethod]
        public void Mid0092AllRevisions()
        {
            string pack = @"00200092            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(MID_0092), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
