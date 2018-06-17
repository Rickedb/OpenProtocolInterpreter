using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0091 : MidTester
    {
        [TestMethod]
        public void Mid0091AllRevisions()
        {
            string pack = @"00670091   1        01020265535032017-01-25:10:20:20041050101102031";
            var mid = _midInterpreter.Parse<Mid0091>(pack);

            Assert.AreEqual(typeof(Mid0091), mid.GetType());
            Assert.IsNotNull(mid.NumberOfSpindles);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.SyncOverallStatus);
            Assert.IsNotNull(mid.SpindlesStatus);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}
