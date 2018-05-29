using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0020 : MidTester
    {
        [TestMethod]
        public void Mid0020Revision1()
        {
            string package = "00230020            054";
            var mid = _midInterpreter.Parse<MID_0020>(package);

            Assert.AreEqual(typeof(MID_0020), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
