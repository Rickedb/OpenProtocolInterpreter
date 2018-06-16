using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Statistic;

namespace MIDTesters.Statistic
{
    [TestClass]
    public class TestMid0300 : MidTester
    {
        [TestMethod]
        public void Mid0300Revision1()
        {
            string package = "00290300            010020202";
            var mid = _midInterpreter.Parse<MID_0300>(package);

            Assert.AreEqual(typeof(MID_0300), mid.GetType());
            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.HistogramType);
            Assert.AreEqual(package, mid.Pack());
        }
    }
}
