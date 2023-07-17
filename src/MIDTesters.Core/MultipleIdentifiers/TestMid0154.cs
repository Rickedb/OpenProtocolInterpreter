using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    [TestCategory("MultipleIdentifiers")]
    public class TestMid0154 : DefaultMidTests<Mid0154>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0154Revision1()
        {
            string package = "00200154            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0154), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0154ByteRevision1()
        {
            string package = "00200154            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0154), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
