using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    [TestCategory("PowerMACS")]
    public class TestMid0109 : DefaultMidTests<Mid0109>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0109AllRevisions()
        {
            string package = "00200109002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0109), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0109ByteAllRevisions()
        {
            string package = "00200109002         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0109), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
