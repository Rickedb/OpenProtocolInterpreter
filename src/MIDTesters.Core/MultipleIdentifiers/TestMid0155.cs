using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    [TestCategory("MultipleIdentifiers")]
    public class TestMid0155 : DefaultMidTests<Mid0155>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0155Revision1()
        {
            string package = "00200155            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0155), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0155ByteRevision1()
        {
            string package = "00200155            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0155), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
