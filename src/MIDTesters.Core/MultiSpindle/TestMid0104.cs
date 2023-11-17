using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.Core.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0104 : DefaultMidTests<Mid0104>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0104Revision1()
        {
            string pack = @"00320104            013009021015";
            var mid = _midInterpreter.Parse<Mid0104>(pack);

            Assert.AreNotEqual(0, mid.RequestedResultIndex);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0104ByteRevision1()
        {
            string package = @"00320104            013009021015";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0104>(bytes);

            Assert.AreNotEqual(0, mid.RequestedResultIndex);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
