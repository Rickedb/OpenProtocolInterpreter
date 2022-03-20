using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultipleIdentifiers;

namespace MIDTesters.MultipleIdentifiers
{
    [TestClass]
    public class TestMid0150 : MidTester
    {
        [TestMethod]
        public void Mid0150Revision1()
        {
            string identifier = "My identifier less than 100";
            string package = "00470150001         My identifier less than 100";
            var mid = _midInterpreter.Parse<Mid0150>(package);

            var mid0150 = new Mid0150(identifier);
            Assert.AreEqual(typeof(Mid0150), mid.GetType());
            Assert.IsNotNull(mid.IdentifierData);
            Assert.AreEqual(mid0150.Pack(), mid.Pack());
        }

        [TestMethod]
        public void Mid0150ByteRevision1()
        {
            string identifier = "My identifier less than 100";
            string package = "00470150001         My identifier less than 100";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0150>(bytes);

            var mid0150 = new Mid0150(identifier);
            Assert.AreEqual(typeof(Mid0150), mid.GetType());
            Assert.IsNotNull(mid.IdentifierData);
            Assert.IsTrue(mid0150.PackBytes().SequenceEqual(bytes));
        }
    }
}
