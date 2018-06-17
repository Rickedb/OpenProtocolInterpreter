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
            var mid = _midInterpreter.Parse<Mid0019>(package);

            Assert.AreEqual(typeof(Mid0019), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
