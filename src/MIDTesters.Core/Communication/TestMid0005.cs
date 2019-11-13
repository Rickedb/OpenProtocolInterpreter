using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using System.Linq;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0005 : MidTester
    {
        [TestMethod]
        public void Mid0005Revision1()
        {
            string pack = @"00240005            0018";
            var mid = _midInterpreter.Parse<Mid0005>(pack);

            Assert.AreEqual(typeof(Mid0005), mid.GetType());
            Assert.IsNotNull(mid.MidAccepted);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0005ByteRevision1()
        {
            string pack = @"00240005            0018";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0005>(bytes);

            Assert.AreEqual(typeof(Mid0005), mid.GetType());
            Assert.IsNotNull(mid.MidAccepted);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
