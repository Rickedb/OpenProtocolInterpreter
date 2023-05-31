using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Job.Advanced;

namespace MIDTesters.Job.Advanced
{
    [TestClass]
    [TestCategory("Job"), TestCategory("Advanced Job")]
    public class TestMid0130 : DefaultMidTests<Mid0130>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0130Revision1()
        {
            string package = "00210130            1";
            var mid = _midInterpreter.Parse<Mid0130>(package);

            Assert.IsNotNull(mid.JobOffStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0130ByteRevision1()
        {
            string package = "00210130            1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0130>(bytes);

            Assert.IsNotNull(mid.JobOffStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
