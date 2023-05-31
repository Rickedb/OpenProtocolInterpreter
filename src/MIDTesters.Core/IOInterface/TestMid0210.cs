using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0210 : DefaultMidTests<Mid0210>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0210Revision1()
        {
            string package = "00200210   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0210), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0210ByteRevision1()
        {
            string package = "00200210   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0210), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
