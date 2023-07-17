using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    [TestCategory("MultiSpindle")]
    public class TestMid0102 : DefaultMidTests<Mid0102>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0102Revision1()
        {
            string pack = @"00200102            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0102), mid.GetType());
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
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
