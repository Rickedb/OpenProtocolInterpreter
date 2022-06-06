using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0091 : DefaultMidTests<Mid0091>
    {
        [TestMethod]
        public void Mid0091AllRevisions()
        {
            string pack = @"00670091   1        01020265535032017-01-25:10:20:20041050101102031";
            var mid = _midInterpreter.Parse<Mid0091>(pack);

            Assert.IsNotNull(mid.NumberOfSpindles);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.SyncOverallStatus);
            Assert.IsNotNull(mid.SpindlesStatus);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0091ByteAllRevisions()
        {
            string package = @"00670091   1        01020265535032017-01-25:10:20:20041050101102031";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0091>(bytes);

            Assert.IsNotNull(mid.NumberOfSpindles);
            Assert.IsNotNull(mid.SyncTighteningId);
            Assert.IsNotNull(mid.Time);
            Assert.IsNotNull(mid.SyncOverallStatus);
            Assert.IsNotNull(mid.SpindlesStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
