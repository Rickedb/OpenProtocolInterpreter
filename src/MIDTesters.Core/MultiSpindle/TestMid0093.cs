using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0093 : DefaultMidTests<Mid0093>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0093AllRevisions()
        {
            string pack = @"00200093            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0093), mid.GetType());
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0093ByteAllRevisions()
        {
            string package = @"00200093            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0093), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
