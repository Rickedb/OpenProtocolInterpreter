using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0240 : DefaultMidTests<Mid0240>
    {
        [TestMethod]
        public void Mid0240Revision1()
        {
            string package = "00470240            My identifier less than 100";
            var mid = _midInterpreter.Parse<Mid0240>(package);

            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0240ByteRevision1()
        {
            string package = "00470240            My identifier less than 100";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0240>(bytes);

            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
