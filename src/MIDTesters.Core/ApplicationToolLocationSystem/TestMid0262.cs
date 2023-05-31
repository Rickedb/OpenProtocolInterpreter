using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    [TestCategory("ApplicationToolLocationSystem")]
    public class TestMid0262 : DefaultMidTests<Mid0262>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0262Revision1()
        {
            string package = "00300262001         013200078D";
            var mid = _midInterpreter.Parse<Mid0262>(package);

            Assert.IsNotNull(mid.ToolTagId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0262ByteRevision1()
        {
            string package = "00300262001         013200078D";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0262>(bytes);

            Assert.IsNotNull(mid.ToolTagId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
