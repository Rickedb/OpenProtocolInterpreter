using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0004 : DefaultMidTests<Mid0004>
    {
        [TestMethod]
        public void Mid0004Revision1()
        {
            string pack = @"00260004            001802";
            var mid = _midInterpreter.Parse<Mid0004>(pack);

            Assert.IsNotNull(mid.FailedMid);
            Assert.IsNotNull(mid.ErrorCode);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0004ByteRevision1()
        {
            string pack = @"00260004            001802";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0004>(bytes);

            Assert.IsNotNull(mid.FailedMid);
            Assert.IsNotNull(mid.ErrorCode);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
