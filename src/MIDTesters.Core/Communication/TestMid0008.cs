using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0008 : DefaultMidTests<Mid0008>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0008Revision1()
        {
            string pack = @"00430008            002200214lengthequals14";
            var mid = _midInterpreter.Parse<Mid0008>(pack);

            Assert.IsNotNull(mid.SubscriptionMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0008ByteRevision1()
        {
            string pack = @"00430008            002200214lengthequals14";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0008>(bytes);

            Assert.IsNotNull(mid.SubscriptionMid);
            Assert.IsNotNull(mid.WantedRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
