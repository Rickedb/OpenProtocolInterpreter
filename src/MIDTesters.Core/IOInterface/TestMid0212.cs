using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.IOInterface;

namespace MIDTesters.IOInterface
{
    [TestClass]
    [TestCategory("IOInterface")]
    public class TestMid0212 : DefaultMidTests<Mid0212>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0212Revision1()
        {
            string package = "00200212            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0212), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0212ByteRevision1()
        {
            string package = "00200212            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0212), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
