using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0242 : DefaultMidTests<Mid0242>
    {
        [TestMethod]
        public void Mid0242Revision1()
        {
            string package = "00430242   1        My identifier less than";
            var mid = _midInterpreter.Parse<Mid0242>(package);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0242ByteRevision1()
        {
            string package = "00430242   1        My identifier less than";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0242>(bytes);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
