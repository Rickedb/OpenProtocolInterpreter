using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.AutomaticManualMode;

namespace MIDTesters.AutomaticManualMode
{
    [TestClass]
    public class TestMid0401 : DefaultMidTests<Mid0401>
    {
        [TestMethod]
        public void Mid0401Revision1()
        {
            string package = "00210401   1        1";
            var mid = _midInterpreter.Parse<Mid0401>(package);

            Assert.IsNotNull(mid.ManualAutomaticMode);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0401ByteRevision1()
        {
            string package = "00210401   1        1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0401>(bytes);

            Assert.IsNotNull(mid.ManualAutomaticMode);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
