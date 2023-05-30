using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0102 : DefaultMidTests<Mid0102>
    {
        [TestMethod]
        public void Mid0102Revision1()
        {
            string pack = @"00200102            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0102), mid.GetType());
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0102ByteRevision1()
        {
            string package = @"00200102            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0102), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
