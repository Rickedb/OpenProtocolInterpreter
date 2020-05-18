using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;
using System.Linq;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0102 : MidTester
    {
        [TestMethod]
        public void Mid0102Revision1()
        {
            string pack = @"00200102            ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0102), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0102ByteRevision1()
        {
            string package = @"00200102            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0102), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
