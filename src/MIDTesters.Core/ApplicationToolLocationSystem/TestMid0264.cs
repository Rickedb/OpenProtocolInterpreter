using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationToolLocationSystem;

namespace MIDTesters.ApplicationToolLocationSystem
{
    [TestClass]
    [TestCategory("ApplicationToolLocationSystem")]
    public class TestMid0264 : DefaultMidTests<Mid0264>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0264Revision1()
        {
            string package = "00200264            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0264), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0264ByteRevision1()
        {
            string package = "00200264            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0264), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
