using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0030 : MidTester
    {
        [TestMethod]
        public void Mid0030AllRevisions()
        {
            string package = "00200030002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0030), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
