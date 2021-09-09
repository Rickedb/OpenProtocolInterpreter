using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.LinkCommunication;
using System.Linq;

namespace MIDTesters.LinkCommunication
{
    [TestClass]
    public class TestMid9997 : MidTester
    {
        [TestMethod]
        public void Mid9997Revision1()
        {
            string package = "00249997001         0061";
            var mid = _midInterpreter.Parse<Mid9997>(package);

            Assert.AreEqual(typeof(Mid9997), mid.GetType());
            Assert.AreNotEqual(0, mid.MidNumber);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid9997ByteRevision1()
        {
            string package = "00249997001         0065";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid9997>(bytes);

            Assert.AreEqual(typeof(Mid9997), mid.GetType());
            Assert.AreNotEqual(0, mid.MidNumber);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
