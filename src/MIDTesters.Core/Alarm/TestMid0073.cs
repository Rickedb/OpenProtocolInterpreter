using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid0073 : DefaultMidTests<Mid0073>
    {
        [TestMethod]
        [TestCategory("ASCII")]
        public void Mid0073AllRevisions()
        {
            string pack = @"00200073002         ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0073), mid.GetType());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("ByteArray")]
        public void Mid0073ByteAllRevisions()
        {
            string pack = @"00200073002         ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0073), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
