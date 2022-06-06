using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0077 : DefaultMidTests<Mid0077>
    {
        [TestMethod]
        public void Mid0077AllRevisions()
        {
            string pack = @"00200077            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0077), mid.GetType());
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0077ByteAllRevisions()
        {
            string pack = @"00200077            ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0077), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
