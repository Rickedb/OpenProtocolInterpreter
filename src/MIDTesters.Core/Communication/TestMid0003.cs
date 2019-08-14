using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using System.Linq;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0003 : MidTester
    {
        [TestMethod]
        public void Mid0003Revision1()
        {
            string pack = @"00200003001         ";
            var mid = _midInterpreter.Parse<Mid0003>(pack);

            Assert.AreEqual(typeof(Mid0003), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0003ByteRevision1()
        {
            string pack = @"00200003001         ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0003>(bytes);

            Assert.AreEqual(typeof(Mid0003), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
