using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0004 : DefaultMidTests<Mid0004>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0004Revision1()
        {
            string pack = @"00260004            001802";
            var mid = _midInterpreter.Parse<Mid0004>(pack);

            Assert.AreEqual(18, mid.FailedMid);
            Assert.AreEqual(Error.ParameterSetIdNotPresent, mid.ErrorCode);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0004ByteRevision1()
        {
            string pack = @"00260004            001802";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0004>(bytes);

            Assert.AreEqual(18, mid.FailedMid);
            Assert.AreEqual(Error.ParameterSetIdNotPresent, mid.ErrorCode);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0004Revision2()
        {
            string pack = @"00270004002         0018021";
            var mid = _midInterpreter.Parse<Mid0004>(pack);

            Assert.AreEqual(18, mid.FailedMid);
            Assert.AreEqual(Error.JobNotRunning, mid.ErrorCode);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0004ByteRevision2()
        {
            string pack = @"00270004002         0018021";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0004>(bytes);

            Assert.AreEqual(18, mid.FailedMid);
            Assert.AreEqual(Error.JobNotRunning, mid.ErrorCode);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0004PackRevision1()
        {
            string pack = @"00260004            001802";

            AssertBuildAndParse(pack, new Mid0004(1)
            {
                FailedMid = 18,
                ErrorCode = Error.ParameterSetIdNotPresent
            }, true);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("Pack")]
        public void Mid0004PackRevision2()
        {
            string pack = @"00270004002         0018021";

            AssertBuildAndParse(pack, new Mid0004(2)
            {
                FailedMid = 18,
                ErrorCode = Error.JobNotRunning
            });
        }
    }
}
