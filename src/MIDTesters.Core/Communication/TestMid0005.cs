using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Communication;

namespace MIDTesters.Communication
{
    [TestClass]
    public class TestMid0005 : DefaultMidTests<Mid0005>
    {
        [TestMethod]
        public void Mid0005Revision1()
        {
            string pack = @"00240005            0018";
            var mid = _midInterpreter.Parse<Mid0005>(pack);

            Assert.IsNotNull(mid.MidAccepted);
            AssertEqualPackages(pack, mid, true);
        }

        [TestMethod]
        public void Mid0005ByteRevision1()
        {
            string pack = @"00240005            0018";
            byte[] bytes = GetAsciiBytes(pack);
            var mid = _midInterpreter.Parse<Mid0005>(bytes);

            Assert.IsNotNull(mid.MidAccepted);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
