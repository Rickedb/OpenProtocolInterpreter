using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid0072 : DefaultMidTests<Mid0072>
    {
        [TestMethod]
        public void Mid0072AllRevisions()
        {
            string pack = @"00200072002         ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0072), mid.GetType());
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        public void Mid0072ByteAllRevisions()
        {
            string pack = @"00200072002         ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0072), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
