using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    [TestCategory("AutomaticManualMode")]
    public class TestMid0411 : DefaultMidTests<Mid0411>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0411Revision1()
        {
            string package = "00240411            0105";
            var mid = _midInterpreter.Parse<Mid0411>(package);

            Assert.IsNotNull(mid.AutoDisableSetting);
            Assert.IsNotNull(mid.CurrentBatch);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0411ByteRevision1()
        {
            string package = "00240411            0105";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0411>(bytes);

            Assert.IsNotNull(mid.AutoDisableSetting);
            Assert.IsNotNull(mid.CurrentBatch);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
