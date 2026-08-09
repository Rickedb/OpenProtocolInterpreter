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

            Assert.AreEqual(22, mid.SubscriptionMid);
            Assert.AreEqual(2, mid.WantedRevision);
            Assert.AreEqual(14, mid.ExtraDataLength);
            Assert.AreEqual("lengthequals14", mid.ExtraData);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0008ByteRevision1()
        {
            string pack = @"00430008            002200214lengthequals14";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0008>(bytes);

            Assert.AreEqual(22, mid.SubscriptionMid);
            Assert.AreEqual(2, mid.WantedRevision);
            Assert.AreEqual(14, mid.ExtraDataLength);
            Assert.AreEqual("lengthequals14", mid.ExtraData);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0008PackRevision1()
        {
            string pack = @"00430008            002200214lengthequals14";

            AssertBuildAndParse(pack, new Mid0008()
            {
                SubscriptionMid = 22,
                WantedRevision = 2,
                ExtraData = "lengthequals14"
            }, true);
        }
    }
}
