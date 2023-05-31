using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0046 : DefaultMidTests<Mid0046>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0046Revision1()
        {
            string package = "00240046001         0102";
            var mid = _midInterpreter.Parse<Mid0046>(package);

            Assert.IsNotNull(mid.PrimaryTool);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0046ByteRevision1()
        {
            string package = "00240046001         0102";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0046>(bytes);

            Assert.IsNotNull(mid.PrimaryTool);
            AssertEqualPackages(bytes, mid);
        }
    }
}
