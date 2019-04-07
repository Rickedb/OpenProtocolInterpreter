using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0072 : MidTester
    {
        [TestMethod]
        public void Mid0072AllRevisions()
        {
            string pack = @"00200072002         ";
            var mid = _midInterpreter.Parse<Mid0072>(pack);

            Assert.AreEqual(typeof(Mid0072), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0072ByteAllRevisions()
        {
            string pack = @"00200072002         ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0072>(bytes);

            Assert.AreEqual(typeof(Mid0072), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
