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

            Assert.IsNotNull(mid.BoltData);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0108ByteAllRevisions()
        {
            string package = "00210108002         1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0108>(bytes);

            Assert.IsNotNull(mid.BoltData);
            AssertEqualPackages(bytes, mid);
        }
    }
}
