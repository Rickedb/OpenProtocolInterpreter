using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;
using System.Linq;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    public class TestMid0108 : MidTester
    {
        [TestMethod]
        public void Mid0108AllRevisions()
        {
            string package = "00210108002         1";
            var mid = _midInterpreter.Parse<Mid0108>(package);

            Assert.AreEqual(typeof(Mid0108), mid.GetType());
            Assert.IsNotNull(mid.BoltData);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0108ByteAllRevisions()
        {
            string package = "00210108002         1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0108>(bytes);

            Assert.AreEqual(typeof(Mid0108), mid.GetType());
            Assert.IsNotNull(mid.BoltData);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
