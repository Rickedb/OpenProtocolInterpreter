using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Vin;

namespace MIDTesters.Vin
{
    [TestClass]
    public class TestMid0051 : DefaultMidTests<Mid0051>
    {
        [TestMethod]
        public void Mid0051AllRevisions()
        {
            string package = "002000510011        ";
            var mid = _midInterpreter.Parse(package);

            Assert.AreEqual(typeof(Mid0051), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        public void Mid0051ByteAllRevisions()
        {
            string package = "002000510011        ";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse(bytes);

            Assert.AreEqual(typeof(Mid0051), mid.GetType());
            Assert.IsTrue(mid.Header.NoAckFlag);
            AssertEqualPackages(bytes, mid);
        }
    }
}
