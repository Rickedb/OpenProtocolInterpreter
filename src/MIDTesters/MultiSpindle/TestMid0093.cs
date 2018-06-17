using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0093 : MidTester
    {
        [TestMethod]
        public void Mid0093AllRevisions()
        {
            string pack = @"00200093            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0093), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
