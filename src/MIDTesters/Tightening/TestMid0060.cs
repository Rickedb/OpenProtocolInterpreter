using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0060 : MidTester
    {
        [TestMethod]
        public void Mid0060AllRevisions()
        {
            string package = "00200060998         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0060), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
