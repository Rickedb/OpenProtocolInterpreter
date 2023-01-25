using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0150 : DefaultMidTests<Mid0150>
    {
        [TestMethod]
        public void Mid0150Revision1()
        {
            string identifier = "My identifier less than 100";
            string package = "00470150001         My identifier less than 100";
            var mid = _midInterpreter.Parse<Mid0150>(package);

            var mid0150 = new Mid0150(identifier);
            Assert.IsNotNull(mid.IdentifierData);
            AssertEqualPackages(package, mid0150);
        }

        [TestMethod]
        public void Mid0150ByteRevision1()
        {
            string identifier = "My identifier less than 100";
            string package = "00470150001         My identifier less than 100";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0150>(bytes);

            var mid0150 = new Mid0150(identifier);
            Assert.IsNotNull(mid.IdentifierData);
            AssertEqualPackages(bytes, mid0150);
        }

        [TestMethod]
        public void Mid0150ShouldTruncateIdentifier()
        {
            string identifier = "the phrase the quick brown fox jumps over the lazy dog should test all the letter keys in your keyboard"; //103 characters

            var mid0150 = new Mid0150(identifier);
            Assert.IsNotNull(mid0150.IdentifierData);
            Assert.AreEqual(identifier.Substring(0, 100), mid0150.IdentifierData);
            Assert.IsTrue(mid0150.Pack().Length == 120);
        }
    }
}
