using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0154 : DefaultMidTests<Mid0154>
    {
        [TestMethod]
        public void Mid0154Revision1()
        {
            string package = "00200154            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0154), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
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
