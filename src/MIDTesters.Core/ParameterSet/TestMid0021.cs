using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.ParameterSet;

namespace MIDTesters.ParameterSet
{
    [TestClass]
    public class TestMid0021 : DefaultMidTests<Mid0021>
    {
        [TestMethod]
        public void Mid0021Revision1()
        {
            string package = "00200021   1        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0021), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(package, mid, true);
        }

        [TestMethod]
        public void Mid0021ByteRevision1()
        {
            string package = "00200021   1        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0021), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid, true);
        }
    }
}
