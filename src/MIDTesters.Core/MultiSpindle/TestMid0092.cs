using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0092 : DefaultMidTests<Mid0092>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0092AllRevisions()
        {
            string pack = @"00200092            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0092), mid.GetType());
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0092ByteAllRevisions()
        {
            string package = @"00200092            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0092), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
