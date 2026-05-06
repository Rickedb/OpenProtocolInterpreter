using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Hvo;

namespace MIDTesters.Hvo
{
    [TestClass]
    [TestCategory("Hvo")]
    public class TestMid0510 : DefaultMidTests<Mid0510>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0510Revision1()
        {
            string package = "00200510            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0510), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0510ByteRevision1()
        {
            string package = "00200510            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0510), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
