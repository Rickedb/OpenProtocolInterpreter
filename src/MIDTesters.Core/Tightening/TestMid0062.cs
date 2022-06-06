using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;
using System.Linq;

namespace MIDTesters.Tightening
{
    [TestClass]
    public class TestMid0062 : MidTester
    {
        [TestMethod]
        public void Mid0062AllRevisions()
        {
            string package = "00200062005         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0062), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0062ByteAllRevisions()
        {
            string package = "00200062005         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0062), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
