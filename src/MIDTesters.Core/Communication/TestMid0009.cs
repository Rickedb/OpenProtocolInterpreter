using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0009 : DefaultMidTests<Mid0009>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0009Revision1()
        {
            string pack = @"00430009            002200214lengthequals14";
            var mid = _midInterpreter.Parse<Mid0009>(pack);

            Assert.IsNotNull(mid.UnsubscriptionMid);
            Assert.IsNotNull(mid.ExtraDataRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0009ByteRevision1()
        {
            string pack = @"00430009            002200214lengthequals14";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0009>(bytes);

            Assert.IsNotNull(mid.UnsubscriptionMid);
            Assert.IsNotNull(mid.ExtraDataRevision);
            Assert.IsNotNull(mid.ExtraDataLength);
            Assert.IsNotNull(mid.ExtraData);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
