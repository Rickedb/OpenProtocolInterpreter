using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0213 : DefaultMidTests<Mid0213>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0213Revision1()
        {
            string package = "00200213            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0213), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0213ByteRevision1()
        {
            string package = "00200213            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0213), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
