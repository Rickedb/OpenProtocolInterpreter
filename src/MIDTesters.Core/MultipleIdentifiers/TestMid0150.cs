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
            string package = "00470150001         My identifier less than 100";
            var mid = _midInterpreter.Parse<Mid0150>(package);

            Assert.AreEqual(typeof(Mid0150), mid.GetType());
            Assert.IsNotNull(mid.IdentifierData);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0150ByteRevision1()
        {
            string package = "00470150001         My identifier less than 100";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0150>(bytes);

            Assert.AreEqual(typeof(Mid0150), mid.GetType());
            Assert.IsNotNull(mid.IdentifierData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
