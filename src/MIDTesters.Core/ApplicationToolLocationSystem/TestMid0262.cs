using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0262 : DefaultMidTests<Mid0262>
    {
        [TestMethod]
        public void Mid0262Revision1()
        {
            string package = "00300262001         013200078D";
            var mid = _midInterpreter.Parse<Mid0262>(package);

            Assert.IsNotNull(mid.ToolTagId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
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
