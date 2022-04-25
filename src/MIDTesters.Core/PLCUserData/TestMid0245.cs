using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0245 : DefaultMidTests<Mid0245>
    {
        [TestMethod]
        public void Mid0245Revision1()
        {
            string package = "00460245            022My identifier less than";
            var mid = _midInterpreter.Parse<Mid0245>(package);

            Assert.IsNotNull(mid.Offset);
            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0245ByteRevision1()
        {
            string package = "00460245            022My identifier less than";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0245>(bytes);

            Assert.IsNotNull(mid.Offset);
            Assert.IsNotNull(mid.UserData);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
