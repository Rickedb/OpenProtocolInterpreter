using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PLCUserData;

namespace MIDTesters.PLCUserData
{
    [TestClass]
    public class TestMid0244 : DefaultMidTests<Mid0244>
    {
        [TestMethod]
        public void Mid0244Revision1()
        {
            string package = "00200244            ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0244), mid.GetType());
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0244ByteRevision1()
        {
            string package = "00200244            ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0244), mid.GetType());
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
