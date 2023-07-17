using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    [TestCategory("Time")]
    public class TestMid0082 : DefaultMidTests<Mid0082>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0082Revision1()
        {
            string pack = @"00390082            2017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0082>(pack);

            Assert.IsNotNull(mid.Time);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0082ByteRevision1()
        {
            string package = @"00390082            2017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0082>(bytes);

            Assert.IsNotNull(mid.Time);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
