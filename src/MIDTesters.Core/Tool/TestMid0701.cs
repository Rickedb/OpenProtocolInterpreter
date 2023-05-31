using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    [TestCategory("Tool")]
    public class TestMid0701 : DefaultMidTests<Mid0701>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0701Revision1()
        {
            string package = "02110701001         0020001Tool 1 Serial number          Tool 1 Model Name             Tool 1 Model Article Number   0002Tool 2 Serial number          Tool 2 Model Name             Tool 2 Model Article Number   ";
            var mid = _midInterpreter.Parse<Mid0701>(package);

            Assert.IsNotNull(mid.Tools);
            Assert.AreNotEqual(0, mid.TotalTools);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0701ByteRevision1()
        {
            string package = "02110701001         0020001Tool 1 Serial number          Tool 1 Model Name             Tool 1 Model Article Number   0002Tool 2 Serial number          Tool 2 Model Name             Tool 2 Model Article Number   ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0701>(bytes);

            Assert.IsNotNull(mid.Tools);
            Assert.AreNotEqual(0, mid.TotalTools);
            AssertEqualPackages(bytes, mid);
        }
    }
}
