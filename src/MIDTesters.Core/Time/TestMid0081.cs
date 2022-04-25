using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Time;

namespace MIDTesters.Time
{
    [TestClass]
    public class TestMid0081 : DefaultMidTests<Mid0081>
    {
        [TestMethod]
        public void Mid0081Revision1()
        {
            string pack = @"00390081            2017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0081>(pack);

            Assert.IsNotNull(mid.Time);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0081ByteRevision1()
        {
            string package = @"00390081            2017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0081>(bytes);

            Assert.IsNotNull(mid.Time);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
