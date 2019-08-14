using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;
using System.Linq;

namespace MIDTesters.Job.Advanced
{
    /// <summary>
    /// Summary description for TestMid0123
    /// </summary>
    [TestClass]
    public class TestMid0123 : MidTester
    {
        [TestMethod]
        public void Mid0123Revision1()
        {
            string package = "00200123   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0123), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.AreEqual(package, mid.Pack());
        }

        [TestMethod]
        public void Mid0123ByteRevision1()
        {
            string package = "00200123   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0123), mid.GetType());
            Assert.IsNotNull(mid.HeaderData.NoAckFlag);
            Assert.IsTrue(mid.PackBytes().SequenceEqual(bytes));
        }
    }
}
