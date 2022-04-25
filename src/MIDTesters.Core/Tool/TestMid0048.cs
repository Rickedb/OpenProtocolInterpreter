using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tool;

namespace MIDTesters.Tool
{
    [TestClass]
    public class TestMid0048 : DefaultMidTests<Mid0048>
    {
        [TestMethod]
        public void Mid0048Revision1()
        {
            string package = "00450048001         0107022017-12-01:20:12:45";
            var mid = _midInterpreter.Parse<Mid0048>(package);

            Assert.IsNotNull(mid.PairingStatus);
            Assert.IsNotNull(mid.TimeStamp);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0047ByteRevision1()
        {
            string package = "00450048001         0107022017-12-01:20:12:45";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0048>(bytes);

            Assert.IsNotNull(mid.PairingStatus);
            Assert.IsNotNull(mid.TimeStamp);
            AssertEqualPackages(bytes, mid);
        }
    }
}
