using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using System.Linq;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0001 : MidTester
    {
        [TestMethod]
        public void Mid0001AllRevisions()
        {
            var package = "00200001003         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0001AllByteRevisions()
        {
            var package = "00200001003         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0001Revision7()
        {
            var package = "00230001007         011";
            var mid = _midInterpreter.Parse<Mid0001>(package);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.IsNotNull(mid.OptionalKeepAlive);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0001ByteRevision7()
        {
            var package = "00230001007         011";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0001>(bytes);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.IsNotNull(mid.OptionalKeepAlive);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
