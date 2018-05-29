using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0018 : MidTester
    {
        [TestMethod]
        public void Mid0018Revision1()
        {
            string package = "00230018001         022";
            var mid = _midInterpreter.Parse<MID_0018>(package);

            Assert.AreEqual(typeof(MID_0018), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
