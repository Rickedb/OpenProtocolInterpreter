using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using System.Linq;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0006 : MidTester
    {
        [TestMethod]
        public void Mid0006Revision1()
        {
            string pack = @"00430006            001800214lengthequals14";
            var mid = _midInterpreter.Parse<Mid0006>(pack);

            Assert.AreEqual(typeof(Mid0006), mid.GetType());
            Assert.IsNotNull(mid.RequestedMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0006ByteRevision1()
        {
            string pack = @"00430006            001800214lengthequals14";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0006>(bytes);

            Assert.AreEqual(typeof(Mid0006), mid.GetType());
            Assert.IsNotNull(mid.RequestedMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
