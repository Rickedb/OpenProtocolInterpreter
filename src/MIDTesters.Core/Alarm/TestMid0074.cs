using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid0074 : DefaultMidTests<Mid0074>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0074Revision1()
        {
            string pack = @"00240074001         E851";
            var mid = _midInterpreter.Parse<Mid0074>(pack);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(4, mid.ErrorCode.Length);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0074ByteRevision1()
        {
            string pack = @"00240074001         E851";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0074>(bytes);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(4, mid.ErrorCode.Length);
            AssertEqualPackages(bytes, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ASCII")]
        public void Mid0074Revision2()
        {
            string pack = @"00250074002         E8514";
            var mid = _midInterpreter.Parse<Mid0074>(pack);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(5, mid.ErrorCode.Length);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        [TestCategory("Revision 2"), TestCategory("ByteArray")]
        public void Mid0074ByteRevision2()
        {
            string pack = @"00250074002         E8514";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0074>(bytes);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(5, mid.ErrorCode.Length);
            AssertEqualPackages(bytes, mid);
        }
    }
}
