using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Alarm;

namespace MIDTesters.Alarm
{
    [TestClass]
    [TestCategory("Alarm")]
    public class TestMid0070 : DefaultMidTests<Mid0070>
    {
        [TestMethod]
        public void Mid0070AllRevisions()
        {
            string pack = @"002000700021        ";
            var mid = _midInterpreter.Parse<Mid0070>(pack);

            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(pack, mid);
        }

        [TestMethod]
        public void Mid0070ByteAllRevisions()
        {
            string pack = @"002000700021        ";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0070>(bytes);

            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid);
        }
    }
}
