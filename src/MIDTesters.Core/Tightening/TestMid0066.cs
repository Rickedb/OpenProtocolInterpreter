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
            string package = "00240066001         0114";
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
            string package = "00240066001         0114";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0066>(bytes);

            Assert.AreEqual(typeof(Mid0066), mid.GetType());
            Assert.IsNotNull(mid.NumberOfOfflineResults);
            Assert.AreEqual(14, mid.NumberOfOfflineResults);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0066Revision2()
        {
            string package = "00300066002         0101402011";
            var mid = _midInterpreter.Parse<Mid0066>(package);

            Assert.AreEqual(typeof(Mid0066), mid.GetType());
            Assert.IsNotNull(mid.NumberOfOfflineResults);
            Assert.IsNotNull(mid.NumberOfOfflineCurves);
            Assert.AreEqual(14, mid.NumberOfOfflineResults);
            Assert.AreEqual(11, mid.NumberOfOfflineCurves);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0066ByteRevision2()
        {
            string package = "00300066002         0101402011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0066>(bytes);

            Assert.AreEqual(typeof(Mid0066), mid.GetType());
            Assert.IsNotNull(mid.NumberOfOfflineResults);
            Assert.IsNotNull(mid.NumberOfOfflineCurves);
            Assert.AreEqual(14, mid.NumberOfOfflineResults);
            Assert.AreEqual(11, mid.NumberOfOfflineCurves);
            AssertEqualPackages(package, mid);
        }
    }
}
