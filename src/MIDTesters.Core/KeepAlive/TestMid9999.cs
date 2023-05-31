using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.KeepAlive;

namespace MIDTesters.KeepAlive
{
    [TestClass]
    [TestCategory("KeepAlive")]
    public class TestMid9999 : DefaultMidTests<Mid9999>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid9999Revision1()
        {
            string package = "00209999            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid9999), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid9999ByteRevision1()
        {
            string package = "00209999            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid9999), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
