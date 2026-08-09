using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    [TestCategory("ParameterSet")]
    public class TestMid0022 : DefaultMidTests<Mid0022>
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0022Revision1()
        {
            string package = "00210022   1        1";
            var mid = _midInterpreter.Parse<Mid0022>(package);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsTrue(mid.RelayStatus);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0022ByteRevision1()
        {
            string package = "00210022   1        1";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0022>(bytes);

            Assert.IsTrue(mid.Header.NoAckFlag);
            Assert.IsTrue(mid.RelayStatus);
            AssertEqualPackages(bytes, mid, true);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("Pack")]
        public void Mid0022PackRevision1()
        {
            string package = "00210022   1        1";

            AssertBuildAndParse(package, new Mid0022()
            {
                Header = { NoAckFlag = true },
                RelayStatus = true
            }, true);
        }
    }
}
