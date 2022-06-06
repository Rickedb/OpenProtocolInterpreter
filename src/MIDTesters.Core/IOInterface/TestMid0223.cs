using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    public class TestMid0223 : DefaultMidTests<Mid0223>
    {
        [TestMethod]
        public void Mid0223Revision1()
        {
            string package = "00230223            066";
            var mid = _midInterpreter.Parse<Mid0223>(package);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0223ByteRevision1()
        {
            string package = "00230223            066";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0223>(bytes);

            Assert.IsNotNull(mid.DigitalInputNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
