using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    [TestCategory("Communication")]
    public class TestMid0006 : DefaultMidTests<Mid0006>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0006Revision1()
        {
            string pack = @"00430006            001800214lengthequals14";
            var mid = _midInterpreter.Parse<Mid0006>(pack);

            Assert.AreEqual(typeof(Mid0006), mid.GetType());
            Assert.AreEqual(18, mid.RequestedMid);
            Assert.AreEqual(2, mid.WantedRevision);
            Assert.AreEqual(14, mid.ExtraDataLength);
            Assert.AreEqual("lengthequals14", mid.ExtraData);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0006ByteRevision1()
        {
            string pack = @"00430006            001800214lengthequals14";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0006>(bytes);

            Assert.AreEqual(typeof(Mid0006), mid.GetType());
            Assert.AreEqual(18, mid.RequestedMid);
            Assert.AreEqual(2, mid.WantedRevision);
            Assert.AreEqual(14, mid.ExtraDataLength);
            Assert.AreEqual("lengthequals14", mid.ExtraData);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
