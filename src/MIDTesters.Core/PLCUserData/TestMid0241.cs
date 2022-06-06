using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0241 : DefaultMidTests<Mid0241>
    {
        [TestMethod]
        public void Mid0241Revision1()
        {
            string package = "00200241   1        ";
            var mid = _midInterpreter.Parse<Mid0241>(package);

            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0241ByteRevision1()
        {
            string package = "00200241   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
