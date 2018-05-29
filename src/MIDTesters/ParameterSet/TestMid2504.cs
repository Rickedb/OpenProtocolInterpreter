using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid2504 : MidTester
    {
        [TestMethod]
        public void Mid2504Revision1()
        {
            string package = "00232504001         010";
            var mid = _midInterpreter.Parse<MID_2504>(package);

            Assert.AreEqual(typeof(MID_2504), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
