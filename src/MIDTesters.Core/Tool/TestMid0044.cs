using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0044 : DefaultMidTests<Mid0044>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0044AllRevisions()
        {
            string package = "00200044            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0044), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0044ByteAllRevisions()
        {
            string package = "00200044            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0044), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
