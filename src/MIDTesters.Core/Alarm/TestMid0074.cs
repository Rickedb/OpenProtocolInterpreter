using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    public class TestMid0074 : DefaultMidTests<Mid0074>
    {
        [TestMethod]
        public void Mid0074Revision1()
        {
            string pack = @"00240074001         E851";
            var mid = _midInterpreter.Parse<Mid0074>(pack);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(4, mid.ErrorCode.Length);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
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
        public void Mid0074Revision2()
        {
            string pack = @"00250074002         E8514";
            var mid = _midInterpreter.Parse<Mid0074>(pack);

            Assert.IsNotNull(mid.ErrorCode);
            Assert.AreEqual(5, mid.ErrorCode.Length);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
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
