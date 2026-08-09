using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0020 : DefaultMidTests<Mid0020>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0020Revision1()
        {
            string package = "00230020            054";
            var mid = _midInterpreter.Parse<Mid0020>(package);

            Assert.AreEqual(54, mid.ParameterSetId);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0020ByteRevision1()
        {
            string package = "00230020            054";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0020>(bytes);

            Assert.AreEqual(54, mid.ParameterSetId);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0020PackRevision1()
        {
            string package = "00230020            054";

            AssertBuildAndParse(package, new Mid0020()
            {
                ParameterSetId = 54
            }, true);
        }
    }
}
