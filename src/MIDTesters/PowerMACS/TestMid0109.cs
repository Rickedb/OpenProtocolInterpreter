using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    public class TestMid0109 : MidTester
    {
        [TestMethod]
        public void Mid0109AllRevisions()
        {
            string package = "00200109002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0109), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
