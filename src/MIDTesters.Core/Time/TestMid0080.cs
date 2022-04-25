using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    public class TestMid0080 : DefaultMidTests<Mid0080>
    {
        [TestMethod]
        public void Mid0080AllRevisions()
        {
            string pack = @"00200080            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0080), mid.GetType());
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0080ByteAllRevisions()
        {
            string package = "00200080            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0080), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
