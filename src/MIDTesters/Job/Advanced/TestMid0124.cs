using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0124 : MidTester
    {
        [TestMethod]
        public void Mid0124Revision1()
        {
            string package = "00200124   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(MID_0124), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
