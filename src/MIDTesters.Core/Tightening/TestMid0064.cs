using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;
using System.Linq;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0064 : MidTester
    {
        [TestMethod]
        public void Mid0064Revision1()
        {
            string package = "00300064001         0123456789";
            var mid = _midInterpreter.Parse<Mid0064>(package);

            Assert.AreEqual(typeof(Mid0064), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0064ByteRevision1()
        {
            string package = "00300064001         0123456789";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0064>(bytes);

            Assert.AreEqual(typeof(Mid0064), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
