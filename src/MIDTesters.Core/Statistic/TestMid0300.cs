using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Statistic;

namespace MIDTesters.Statistic
{
    [TestClass]
    [TestCategory("Statistic")]
    public class TestMid0300 : DefaultMidTests<Mid0300>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0300Revision1()
        {
            string package = "00290300            010020202";
            var mid = _midInterpreter.Parse<Mid0300>(package);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(HistogramType.Current, mid.HistogramType);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0300ByteRevision1()
        {
            string package = "00290300            010020202";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0300>(bytes);

            Assert.AreEqual(2, mid.ParameterSetId);
            Assert.AreEqual(HistogramType.Current, mid.HistogramType);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0300PackRevision1()
        {
            string package = "00290300            010020202";

            AssertBuildAndParse(package, new Mid0300()
            {
                ParameterSetId = 2,
                HistogramType = HistogramType.Current
            }, true);
        }
    }
}
