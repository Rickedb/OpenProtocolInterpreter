using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job;
using System.Linq;

namespace MIDTesters.Job
{
    [TestClass]
    public class TestMid0037 : MidTester
    {
        [TestMethod]
        public void Mid0037AllRevisions()
        {
            string package = "00200037001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0037), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0037ByteAllRevisions()
        {
            string package = "00200037001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0037), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
