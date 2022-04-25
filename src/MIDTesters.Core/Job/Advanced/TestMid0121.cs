using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    public class TestMid0121 : DefaultMidTests<Mid0121>
    {
        [TestMethod]
        public void Mid0121Revision1()
        {
            string package = "00200121   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0121), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0121ByteRevision1()
        {
            string package = "00200121   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0121), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
