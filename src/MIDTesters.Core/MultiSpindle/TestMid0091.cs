using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

using System.Collections.Generic;
namespace MIDTesters.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0091 : DefaultMidTests<Mid0091>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0091AllRevisions()
        {
            string pack = @"00670091   1        01020265535032017-01-25:10:20:20041050101102031";
            var mid = _midInterpreter.Parse<Mid0091>(pack);

            Assert.AreEqual(2, mid.NumberOfSpindles);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesStatus.Count);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0091ByteAllRevisions()
        {
            string package = @"00670091   1        01020265535032017-01-25:10:20:20041050101102031";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0091>(bytes);

            Assert.AreEqual(2, mid.NumberOfSpindles);
            Assert.AreEqual(65535, mid.SyncTighteningId);
            Assert.AreEqual(new DateTime(2017, 1, 25, 10, 20, 20), mid.Time);
            Assert.IsTrue(mid.SyncOverallStatus);
            Assert.AreEqual(2, mid.SpindlesStatus.Count);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Pack")]
        public void Mid0091PackAllRevisions()
        {
            string pack = @"00670091   1        01020265535032017-01-25:10:20:20041050101102031";

            AssertBuildAndParse(pack, new Mid0091()
            {
                Header = { NoAckFlag = true },
                NumberOfSpindles = 2,
                SyncTighteningId = 65535,
                Time = new DateTime(2017, 1, 25, 10, 20, 20),
                SyncOverallStatus = true,
                SpindlesStatus = new List<SpindleStatus>()
                {
                    new SpindleStatus() { SpindleNumber = 1, ChannelId = 1, SyncOverallStatus = true },
                    new SpindleStatus() { SpindleNumber = 2, ChannelId = 3, SyncOverallStatus = true }
                }
            }, true);
        }
    }
}
