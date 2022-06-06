using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    public class TestMid0265 : DefaultMidTests<Mid0265>
    {
        [TestMethod]
        public void Mid0265Revision1()
        {
            string package = "00340265001         013200078D0202";
            var mid = _midInterpreter.Parse<Mid0265>(package);

            Assert.IsNotNull(mid.ToolTagId);
            Assert.IsNotNull(mid.ToolStatus);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0265ByteRevision1()
        {
            string package = "00340265001         013200078D0202";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0265>(bytes);

            Assert.IsNotNull(mid.ToolTagId);
            Assert.IsNotNull(mid.ToolStatus);
            AssertEqualPackages(bytes, mid);
        }
    }
}
