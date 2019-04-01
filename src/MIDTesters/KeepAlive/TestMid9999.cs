using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.KeepAlive;
using System.Linq;

namespace MIDTesters.KeepAlive
{
    [TestClass]
    public class TestMid9999 : MidTester
    {
        [TestMethod]
        public void Mid9999Revision1()
        {
            string package = "00209999            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid9999), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid9999ByteRevision1()
        {
            string package = "00209999            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid9999), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
