using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0019 : DefaultMidTests<Mid0019>
    {
        [TestMethod]
        public void Mid0019Revision1()
        {
            string package = "00250019            77750";
            var mid = _midInterpreter.Parse<Mid0019>(package);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0019ByteRevision1()
        {
            string package = "00250019            77750";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0019>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            Assert.IsNotNull(mid.BatchSize);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
