using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    [TestCategory("Job"), TestCategory("Advanced Job")]
    public class TestMid0124 : DefaultMidTests<Mid0124>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0124Revision1()
        {
            string package = "00200124   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0124), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0124ByteRevision1()
        {
            string package = "00200124   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0124), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
