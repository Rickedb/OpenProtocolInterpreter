using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;
using System.Linq;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0010 : MidTester
    {
        [TestMethod]
        public void Mid0010AllRevisions()
        {
            string package = "00200010002         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0010), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0010ByteAllRevisions()
        {
            string package = "00200010002         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0010), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
