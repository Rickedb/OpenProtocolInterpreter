using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    [TestCategory("PowerMACS")]
    public class TestMid0108 : DefaultMidTests<Mid0108>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0108AllRevisions()
        {
            string package = "00210108002         1";
            var mid = _midInterpreter.Parse<Mid0108>(package);

            Assert.IsTrue(mid.BoltData);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0108ByteAllRevisions()
        {
            string package = "00210108002         1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0108>(bytes);

            Assert.IsTrue(mid.BoltData);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0108PackAllRevisions()
        {
            string package = "00210108002         1";

            AssertBuildAndParse(package, new Mid0108(2)
            {
                BoltData = true
            });
        }
    }
}
