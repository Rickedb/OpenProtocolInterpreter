using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;
using System.Linq;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0127 : MidTester
    {
        [TestMethod]
        public void Mid0127Revision1()
        {
            string package = "00200127001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0127), mid.GetType());
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0127ByteRevision1()
        {
            string package = "00200127001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0127), mid.GetType());
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
