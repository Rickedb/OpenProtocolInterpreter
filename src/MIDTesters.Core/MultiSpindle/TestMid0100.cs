using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.MultiSpindle;
using System.Linq;

namespace MIDTesters.MultiSpindle
{
    [TestClass]
    public class TestMid0100 : MidTester
    {
        [TestMethod]
        public void Mid0100Revision1()
        {
            string pack = @"00200100001         ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0100ByteRevision1()
        {
            string package = @"00200100001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0100Revision2()
        {
            string pack = @"00300100002         0123456789";
            var mid = _midInterpreter.Parse<Mid0100>(pack);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0100ByteRevision2()
        {
            string package = @"00300100002         0123456789";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0100>(bytes);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }

        [TestMethod]
        public void Mid0100Revision3()
        {
            string pack = @"00310100003         01234567891";
            var mid = _midInterpreter.Parse<Mid0100>(pack);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0100ByteRevision3()
        {
            string package = @"00310100003         01234567891";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0100>(bytes);

            Assert.AreEqual(typeof(Mid0100), mid.GetType());
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
