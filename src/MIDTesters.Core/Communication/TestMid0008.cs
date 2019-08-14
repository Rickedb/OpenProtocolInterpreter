using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using System.Linq;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0008 : MidTester
    {
        [TestMethod]
        public void Mid0008Revision1()
        {
            string pack = @"00430008            002200214lengthequals14";
            var mid = _midInterpreter.Parse<Mid0008>(pack);

            Assert.AreEqual(typeof(Mid0008), mid.GetType());
            Assert.IsNotNull(mid.SubscriptionMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0008ByteRevision1()
        {
            string pack = @"00430008            002200214lengthequals14";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0008>(bytes);

            Assert.AreEqual(typeof(Mid0008), mid.GetType());
            Assert.IsNotNull(mid.SubscriptionMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
