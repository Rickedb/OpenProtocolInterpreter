using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0062 : MidTester
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0062AllRevisions()
        {
            string package = "00200062005         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0062), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0062ByteAllRevisions()
        {
            string package = "00200062005         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0062), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
