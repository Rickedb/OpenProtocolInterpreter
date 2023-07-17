using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    [TestCategory("Job"), TestCategory("Advanced Job")]
    public class TestMid0127 : DefaultMidTests<Mid0127>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0127Revision1()
        {
            string package = "00200127001         ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0127), mid.GetType());
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0127ByteRevision1()
        {
            string package = "00200127001         ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0127), mid.GetType());
            AssertEqualPackages(bytes, mid);
        }
    }
}
