using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    [TestCategory("ApplicationToolLocationSystem")]
    public class TestMid0265 : DefaultMidTests<Mid0265>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0265Revision1()
        {
            string package = "00340265001         013200078D0202";
            var mid = _midInterpreter.Parse<Mid0265>(package);

            Assert.AreEqual("3200078D", mid.ToolTagId);
            Assert.AreEqual(ToolStatus.Inoperable, mid.ToolStatus);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0265ByteRevision1()
        {
            string package = "00340265001         013200078D0202";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0265>(bytes);

            Assert.AreEqual("3200078D", mid.ToolTagId);
            Assert.AreEqual(ToolStatus.Inoperable, mid.ToolStatus);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0265PackRevision1()
        {
            string package = "00340265001         013200078D0202";

            AssertBuildAndParse(package, new Mid0265()
            {
                ToolTagId = "3200078D",
                ToolStatus = ToolStatus.Inoperable
            });
        }
    }
}
