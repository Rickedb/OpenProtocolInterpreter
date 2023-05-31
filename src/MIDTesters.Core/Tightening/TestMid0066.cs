using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0066 : MidTester
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0066Revision1()
        {
            string package = "00220066001         14";
            var mid = _midInterpreter.Parse<Mid0066>(package);

            Assert.AreEqual(typeof(Mid0066), mid.GetType());
            Assert.IsNotNull(mid.NumberOfOfflineResults);
            Assert.AreEqual(14, mid.NumberOfOfflineResults);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0066ByteRevision1()
        {
            string package = "00220066001         14";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0066>(bytes);

            Assert.AreEqual(typeof(Mid0066), mid.GetType());
            Assert.IsNotNull(mid.NumberOfOfflineResults);
            Assert.AreEqual(14, mid.NumberOfOfflineResults);
            AssertEqualPackages(package, mid);
        }
    }
}
