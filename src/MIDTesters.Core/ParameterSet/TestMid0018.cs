using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0018 : DefaultMidTests<Mid0018>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0018Revision1()
        {
            string package = "00230018001         022";
            var mid = _midInterpreter.Parse<Mid0018>(package);

            Assert.AreEqual(22, mid.ParameterSetId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0018ByteRevision1()
        {
            string package = "00230018001         022";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0018>(bytes);

            Assert.AreEqual(22, mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0018PackRevision1()
        {
            string package = "00230018001         022";

            AssertBuildAndParse(package, new Mid0018()
            {
                ParameterSetId = 22
            });
        }
    }
}
