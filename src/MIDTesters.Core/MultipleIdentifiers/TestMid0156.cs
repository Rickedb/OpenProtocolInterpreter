using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0156 : DefaultMidTests<Mid0156>
    {
        [TestMethod]
        public void Mid0156Revision1()
        {
            string package = "00200156            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0156), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0156ByteRevision1()
        {
            string package = "00200156            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0156), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
