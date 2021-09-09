using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.LinkCommunication;
using System.Linq;

namespace MIDTesters.LinkCommunication
{
    [TestClass]
    public class TestMid9998 : MidTester
    {
        [TestMethod]
        public void Mid9998Revision1()
        {
            string package = "00289998            00610003";
            var mid = _midInterpreter.Parse<Mid9998>(package);

            Assert.AreEqual(typeof(Mid9998), mid.GetType());
            Assert.AreNotEqual(0, mid.MidNumber);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid9998ByteRevision1()
        {
            string package = "00289998            00610003";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid9998>(bytes);

            Assert.AreEqual(typeof(Mid9998), mid.GetType());
            Assert.AreNotEqual(0, mid.MidNumber);
            Assert.IsNotNull(mid.ErrorCode);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
