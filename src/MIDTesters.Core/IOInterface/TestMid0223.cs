using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0223 : DefaultMidTests<Mid0223>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0223Revision1()
        {
            string package = "00230223            066";
            var mid = _midInterpreter.Parse<Mid0223>(package);

            Assert.AreEqual(DigitalInputNumber.IdCard, mid.DigitalInputNumber);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0223ByteRevision1()
        {
            string package = "00230223            066";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0223>(bytes);

            Assert.AreEqual(DigitalInputNumber.IdCard, mid.DigitalInputNumber);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
