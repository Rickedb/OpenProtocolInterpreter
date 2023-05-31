using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0222 : DefaultMidTests<Mid0222>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0222Revision1()
        {
            string package = "00200222            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0222), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0222ByteRevision1()
        {
            string package = "00200222            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0222), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
