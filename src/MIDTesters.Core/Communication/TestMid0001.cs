using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0001 : DefaultMidTests<Mid0001>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0001AllRevisions()
        {
            var package = "00200001003         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0001AllByteRevisions()
        {
            var package = "00200001003         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ASCII")]
        public void Mid0001Revision7()
        {
            var package = "00230001007         011";
            var mid = _midInterpreter.Parse<Mid0001>(package);

            Assert.IsNotNull(mid.OptionalKeepAlive);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 7"), TestCategory("ByteArray")]
        public void Mid0001ByteRevision7()
        {
            var package = "00230001007         011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0001>(bytes);

            Assert.IsNotNull(mid.OptionalKeepAlive);
            AssertEqualPackages(bytes, mid);
        }
    }
}
