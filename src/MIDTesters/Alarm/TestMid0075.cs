using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;
using System.Linq;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0075 : MidTester
    {
        [TestMethod]
        public void Mid0075AllRevisions()
        {
            string pack = @"00200075001         ";
            var mid = _midInterpreter.Parse<Mid0075>(pack);

            Assert.AreEqual(typeof(Mid0075), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0075ByteAllRevisions()
        {
            string pack = @"00200075001         ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0075>(bytes);

            Assert.AreEqual(typeof(Mid0075), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
