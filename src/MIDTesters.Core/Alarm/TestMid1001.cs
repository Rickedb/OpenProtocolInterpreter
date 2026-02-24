using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid1001 : DefaultMidTests<Mid1001>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid1001AllRevisions()
        {
            string pack = @"00201001            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid1001), mid.GetType());
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid1001ByteAllRevisions()
        {
            string pack = @"00201001            ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid1001), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
