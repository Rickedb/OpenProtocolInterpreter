using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0018 : DefaultMidTests<Mid0018>
    {
        [TestMethod]
        public void Mid0018Revision1()
        {
            string package = "00230018001         022";
            var mid = _midInterpreter.Parse<Mid0018>(package);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0018ByteRevision1()
        {
            string package = "00230018001         022";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0018>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
