using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0224 : DefaultMidTests<Mid0224>
    {
        [TestMethod]
        public void Mid0224Revision1()
        {
            string package = "00230224            065";
            var mid = _midInterpreter.Parse<Mid0224>(package);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0224ByteRevision1()
        {
            string package = "00230224            065";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0224>(bytes);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
