using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    [TestCategory("ApplicationToolLocationSystem")]
    public class TestMid0263 : DefaultMidTests<Mid0263>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0263Revision1()
        {
            string package = "00200263            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0263), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0263ByteRevision1()
        {
            string package = "00200263            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0263), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
