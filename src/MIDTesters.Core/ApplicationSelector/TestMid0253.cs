using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ApplicationSelector;

namespace MIDTesters.ApplicationSelector
{
    [TestClass]
    [TestCategory("ApplicationSelector")]
    public class TestMid0253 : DefaultMidTests<Mid0253>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0253Revision1()
        {
            string package = "00200253            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0253), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0253ByteRevision1()
        {
            string package = "00200253            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0253), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
