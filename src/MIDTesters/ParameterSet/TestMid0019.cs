using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0019 : MidTester
    {
        [TestMethod]
        public void Mid0019Revision1()
        {
            string package = "00250019            77750";
            var mid = _midInterpreter.Parse<MID_0019>(package);

            Assert.AreEqual(typeof(MID_0019), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
