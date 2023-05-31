using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    [TestCategory("PLCUserData")]
    public class TestMid0243 : DefaultMidTests<Mid0243>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0243Revision1()
        {
            string package = "00200243            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0243), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0243ByteRevision1()
        {
            string package = "00200243            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0243), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
