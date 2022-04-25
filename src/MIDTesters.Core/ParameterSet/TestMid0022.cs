using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;
using System.Linq;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0022 : DefaultMidTests<Mid0022>
    {
        [TestMethod]
        public void Mid0022Revision1()
        {
            string package = "00210022   1        1";
            var mid = _midInterpreter.Parse<Mid0022>(package);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.RelayStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0022ByteRevision1()
        {
            string package = "00210022   1        1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0022>(bytes);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsNotNull(mid.RelayStatus);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
