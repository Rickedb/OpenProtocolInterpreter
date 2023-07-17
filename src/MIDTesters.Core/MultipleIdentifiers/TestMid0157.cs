using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    [TestCategory("MultipleIdentifiers")]
    public class TestMid0157 : DefaultMidTests<Mid0157>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0157Revision1()
        {
            string package = "00200157            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0157), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0157ByteRevision1()
        {
            string package = "00200157            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0157), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
