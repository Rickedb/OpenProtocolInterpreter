using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0411 : MidTester
    {
        [TestMethod]
        public void Mid0411Revision1()
        {
            string package = "00240411            0105";
            var mid = _midInterpreter.Parse<MID_0411>(package);

            Assert.AreEqual(typeof(MID_0411), mid.GetType());
            Assert.IsNotNull(mid.AutoDisableSetting);
            Assert.IsNotNull(mid.CurrentBatch);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
