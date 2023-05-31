using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid2504 : DefaultMidTests<Mid2504>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid2504Revision1()
        {
            string package = "00232504001         010";
            var mid = _midInterpreter.Parse<Mid2504>(package);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid2504ByteRevision1()
        {
            string package = "00232504001         010";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid2504>(bytes);

            Assert.IsNotNull(mid.ParameterSetId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
