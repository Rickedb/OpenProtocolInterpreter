using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0020 : DefaultMidTests<Mid0020>
    {
        [TestMethod]
        public void Mid0020Revision1()
        {
            string package = "00230020            054";
            var mid = _midInterpreter.Parse<Mid0020>(package);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0020ByteRevision1()
        {
            string package = "00230020            054";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0020>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
