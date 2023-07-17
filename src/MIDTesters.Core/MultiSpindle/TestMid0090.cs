using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0090 : DefaultMidTests<Mid0090>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0090AllRevisions()
        {
            string pack = @"00200090   1        ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0090), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0090ByteRevision1()
        {
            string package = @"00200090   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0090), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
