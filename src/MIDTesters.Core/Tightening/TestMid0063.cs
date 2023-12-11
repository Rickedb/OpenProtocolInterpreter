using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0063 : DefaultMidTests<Mid0063>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0063AllRevisions()
        {
            string package = "00200063002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0063), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0063ByteAllRevisions()
        {
            string package = "00200063002         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0063), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
