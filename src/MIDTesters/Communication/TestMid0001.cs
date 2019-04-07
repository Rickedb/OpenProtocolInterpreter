using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using System.Linq;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0001 : MidTester
    {
        private readonly string _package;

        public TestMid0001()
        {
            _package = "00200001003         ";
        }

        [TestMethod]
        public void Mid0001AllRevisions()
        {
            var mid = _midInterpreter.Parse(_package);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.AreEqual(_package, mid.Pack());
        }

        [TestMethod]
        public void Mid0001AllByteRevisions()
        {
            byte[] bytes = GetAsciiBytes(_package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0001), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
