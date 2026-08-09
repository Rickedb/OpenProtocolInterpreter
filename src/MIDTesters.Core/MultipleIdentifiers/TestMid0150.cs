using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    [TestCategory("MultipleIdentifiers")]
    public class TestMid0150 : DefaultMidTests<Mid0150>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0150Revision1()
        {
            string identifier = "My identifier less than 100";
            string package = "00470150001         My identifier less than 100";
            var mid = _midInterpreter.Parse<Mid0150>(package);

            var mid0150 = new Mid0150() { IdentifierData = identifier };
            Assert.AreEqual("My identifier less than 100", mid.IdentifierData);
            AssertEqualPackages(package, mid0150);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0150ByteRevision1()
        {
            string identifier = "My identifier less than 100";
            string package = "00470150001         My identifier less than 100";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0150>(bytes);

            var mid0150 = new Mid0150() { IdentifierData = identifier };
            Assert.AreEqual("My identifier less than 100", mid.IdentifierData);
            AssertEqualPackages(bytes, mid0150);
        }

        [TestMethod]
        public void Mid0150ShouldTruncateIdentifier()
        {
            string identifier = "the phrase the quick brown fox jumps over the lazy dog should test all the letter keys in your keyboard"; //103 characters

            var mid0150 = new Mid0150() { IdentifierData = identifier };
            Assert.IsTrue(mid0150.Pack().Length == 120);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0150PackRevision1()
        {
            string package = "00470150001         My identifier less than 100";

            AssertBuildAndParse(package, new Mid0150()
            {
                IdentifierData = "My identifier less than 100"
            });
        }
    }
}
