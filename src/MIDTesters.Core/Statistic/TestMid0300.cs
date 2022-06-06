using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Statistic;

namespace MIDTesters.Statistic
{
    [TestClass]
    public class TestMid0300 : DefaultMidTests<Mid0300>
    {
        [TestMethod]
        public void Mid0300Revision1()
        {
            string package = "00290300            010020202";
            var mid = _midInterpreter.Parse<Mid0300>(package);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.HistogramType);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0300ByteRevision1()
        {
            string package = "00290300            010020202";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0300>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.HistogramType);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
