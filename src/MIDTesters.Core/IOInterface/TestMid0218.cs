using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0218 : DefaultMidTests<Mid0218>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0218Revision1()
        {
            string package = "00200218            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0218), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0218ByteRevision1()
        {
            string package = "00200218            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0218), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
